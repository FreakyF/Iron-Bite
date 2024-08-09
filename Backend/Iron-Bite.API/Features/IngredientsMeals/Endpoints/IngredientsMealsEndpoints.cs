using AutoMapper;
using Iron_Bite.API.Features.IngredientsMeals.Dtos;
using Iron_Bite.API.Features.IngredientsMeals.Entities;
using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Iron_Bite.API.Features.IngredientsMeals.Endpoints;

public static class IngredientsMealsMealsEndpoints
{
	public static async Task<IResult> GetIngredientsMealsMealsAsync(AppDbContext appDbContext, IMapper mapper)
	{
		var ingredientsMeals = await appDbContext.Nutrients
			.AsNoTracking()
			.ToListAsync();
		return Results.Ok(mapper.Map<IEnumerable<IngredientMealDto>>(ingredientsMeals));
	}

	public static async Task<IResult> GetIngredientMealByIdAsync(AppDbContext appDbContext, IMapper mapper,
		Guid ingredientMealId)
	{
		var ingredientMeal = await appDbContext.IngredientsMeals.FindAsync(ingredientMealId);
		if (ingredientMeal is null) return TypedResults.NotFound();
		return TypedResults.Ok(mapper.Map<IngredientMealDto>(ingredientMeal));
	}

	public static async Task<IResult> CreateIngredientMealAsync(AppDbContext appDbContext, IMapper mapper,
		IngredientMealDto ingredientMealDto)
	{
		var ingredientMeal = mapper.Map<IngredientMeal>(ingredientMealDto);
		await appDbContext.IngredientsMeals.AddAsync(ingredientMeal);
		await appDbContext.SaveChangesAsync();

		return Results.CreatedAtRoute("GetIngredientMeal", new { ingredientMealId = ingredientMeal.Id },
			mapper.Map<IngredientMealDto>(ingredientMeal));
	}

	public static async Task<IResult> UpdateIngredientMealAsync(AppDbContext appDbContext, IMapper mapper,
		Guid ingredientMealId,
		IngredientMealDto ingredientDto)
	{
		var ingredientMeal = await appDbContext.IngredientsMeals.FindAsync(ingredientMealId);
		if (ingredientMeal is null) return TypedResults.NotFound();

		mapper.Map(ingredientDto, ingredientMeal);
		await appDbContext.SaveChangesAsync();

		return TypedResults.NoContent();
	}

	public static async Task<IResult> DeleteIngredientMealAsync(AppDbContext appDbContext, IMapper mapper,
		Guid ingredientMealId)
	{
		var ingredientMeal = await appDbContext.IngredientsMeals.FindAsync(ingredientMealId);
		if (ingredientMeal is null) return TypedResults.NotFound();

		appDbContext.IngredientsMeals.Remove(ingredientMeal);
		await appDbContext.SaveChangesAsync();
		return TypedResults.NoContent();
	}
}