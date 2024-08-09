using AutoMapper;
using Iron_Bite.API.Features.IngredientsMeals.Dtos;
using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Iron_Bite.API.Features.IngredientsMeals.Endpoints;

public static class IngredientsMealsEndpoints
{
	public static void MapIngredientsMealsEndpoints(this WebApplication app)
	{
		app.MapGet("/ingredientsmeals",
			async (AppDbContext appDbContext, IMapper mapper) =>
			{
				TypedResults.Ok(mapper.Map<IEnumerable<IngredientMealDto>>(await appDbContext.IngredientsMeals
					.ToListAsync()));
			});

		app.MapGet("/ingredientsmeals/{ingredientmealId:guid}",
			async (AppDbContext appDbContext, IMapper mapper, Guid ingredientmealId) =>
			{
				TypedResults.Ok(mapper.Map<IngredientMealDto>(await appDbContext.IngredientsMeals
					.FirstOrDefaultAsync(i => i.Id == ingredientmealId)));
			});
	}
}