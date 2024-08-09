using AutoMapper;
using Iron_Bite.API.Features.Meals.Dtos;
using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Iron_Bite.API.Features.Meals.Endpoints;

public static class MealsEndpoints
{
	public static void MapMealsEndpoints(this WebApplication app)
	{
		app.MapGet("/meals",
			async (AppDbContext appDbContext, IMapper mapper, string? name) =>
			{
				TypedResults.Ok(mapper.Map<IEnumerable<MealDto>>(await appDbContext.Meals
					.Where(m => string.IsNullOrEmpty(name) || m.Name.Contains(name)).ToListAsync()));
			});


		app.MapGet("/meals/{mealId:guid}",
			async (AppDbContext appDbContext, IMapper mapper, Guid mealId) =>
			{
				TypedResults.Ok(mapper.Map<MealDto>(await appDbContext.Meals.FirstOrDefaultAsync(m => m.Id == mealId)));
			});
	}
}