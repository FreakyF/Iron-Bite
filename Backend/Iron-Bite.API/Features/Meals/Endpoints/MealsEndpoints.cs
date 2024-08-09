using AutoMapper;
using Iron_Bite.API.Features.Meals.Dtos;
using Iron_Bite.API.Features.Meals.Entities;
using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Iron_Bite.API.Features.Meals.Endpoints;

public static class MealsEndpoints
{
	public static async Task<IResult> GetMealsAsync(AppDbContext appDbContext, IMapper mapper, string? name)
	{
		var meals = await appDbContext.Meals
			.Where(m => string.IsNullOrEmpty(name) || m.Name.Contains(name))
			.AsNoTracking()
			.ToListAsync();
		return Results.Ok(mapper.Map<IEnumerable<MealDto>>(meals));
	}

	public static async Task<IResult> GetMealByIdAsync(AppDbContext appDbContext, IMapper mapper, Guid mealId)
	{
		var meal = await appDbContext.Meals.FindAsync(mealId);
		if (meal is null) return TypedResults.NotFound();
		return TypedResults.Ok(mapper.Map<MealDto>(meal));
	}

	public static async Task<IResult> CreateMealAsync(AppDbContext appDbContext, IMapper mapper, MealDto mealDto)
	{
		var meal = mapper.Map<Meal>(mealDto);
		await appDbContext.Meals.AddAsync(meal);
		await appDbContext.SaveChangesAsync();

		return Results.CreatedAtRoute("GetMeal", new { mealId = meal.Id }, mapper.Map<MealDto>(meal));
	}

	public static async Task<IResult> UpdateMealAsync(AppDbContext appDbContext, IMapper mapper, Guid mealId,
		MealDto mealDto)
	{
		var meal = await appDbContext.Meals.FindAsync(mealId);
		if (meal is null) return TypedResults.NotFound();

		mapper.Map(mealDto, meal);
		await appDbContext.SaveChangesAsync();

		return TypedResults.NoContent();
	}

	public static async Task<IResult> DeleteMealAsync(AppDbContext appDbContext, IMapper mapper, Guid mealId)
	{
		var meal = await appDbContext.Meals.FindAsync(mealId);
		if (meal is null) return TypedResults.NotFound();

		appDbContext.Meals.Remove(meal);
		await appDbContext.SaveChangesAsync();
		return TypedResults.NoContent();
	}
}