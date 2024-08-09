using AutoMapper;
using Iron_Bite.API.Features.Ingredients.Dtos;
using Iron_Bite.API.Features.Ingredients.Entities;
using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Iron_Bite.API.Features.Ingredients.Endpoints;

public static class IngredientsEndpoints
{
	public static async Task<IResult> GetIngredientsAsync(AppDbContext appDbContext, IMapper mapper, string? name)
	{
		var ingredients = await appDbContext.Ingredients
			.Where(m => string.IsNullOrEmpty(name) || m.Name.Contains(name))
			.AsNoTracking()
			.ToListAsync();
		return Results.Ok(mapper.Map<IEnumerable<IngredientDto>>(ingredients));
	}

	public static async Task<IResult> GetIngredientByIdAsync(AppDbContext appDbContext, IMapper mapper, Guid mealId)
	{
		var ingredient = await appDbContext.Ingredients.FindAsync(mealId);
		if (ingredient is null) return TypedResults.NotFound();
		return TypedResults.Ok(mapper.Map<IngredientDto>(ingredient));
	}

	public static async Task<IResult> CreateIngredientAsync(AppDbContext appDbContext, IMapper mapper,
		IngredientDto ingredientDto)
	{
		var ingredient = mapper.Map<Ingredient>(ingredientDto);
		await appDbContext.Ingredients.AddAsync(ingredient);
		await appDbContext.SaveChangesAsync();

		return Results.CreatedAtRoute("GetIngredient", new { ingredientId = ingredient.Id },
			mapper.Map<IngredientDto>(ingredient));
	}

	public static async Task<IResult> UpdateIngredientAsync(AppDbContext appDbContext, IMapper mapper, Guid mealId,
		IngredientDto ingredientDto)
	{
		var ingredient = await appDbContext.Ingredients.FindAsync(mealId);
		if (ingredient is null) return TypedResults.NotFound();

		mapper.Map(ingredientDto, ingredient);
		await appDbContext.SaveChangesAsync();

		return TypedResults.NoContent();
	}

	public static async Task<IResult> DeleteIngredientAsync(AppDbContext appDbContext, IMapper mapper, Guid mealId)
	{
		var ingredient = await appDbContext.Ingredients.FindAsync(mealId);
		if (ingredient is null) return TypedResults.NotFound();

		appDbContext.Ingredients.Remove(ingredient);
		await appDbContext.SaveChangesAsync();
		return TypedResults.NoContent();
	}
}