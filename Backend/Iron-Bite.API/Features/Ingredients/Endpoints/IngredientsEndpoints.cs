using AutoMapper;
using Iron_Bite.API.Features.Ingredients.Dtos;
using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Iron_Bite.API.Features.Ingredients.Endpoints;

public static class IngredientsEndpoints
{
	public static void MapIngredientsEndpoints(this WebApplication app)
	{
		app.MapGet("/ingredients",
			async (AppDbContext appDbContext, IMapper mapper, string? name) =>
			{
				TypedResults.Ok(mapper.Map<IEnumerable<IngredientDto>>(await appDbContext.Ingredients
					.Where(i => string.IsNullOrEmpty(name) || i.Name.Contains(name)).ToListAsync()));
			});

		app.MapGet("/ingredients/{ingredientId:guid}",
			async (AppDbContext appDbContext, IMapper mapper, Guid ingredientId) =>
			{
				TypedResults.Ok(mapper.Map<IngredientDto>(await appDbContext.Ingredients
					.FirstOrDefaultAsync(i => i.Id == ingredientId)));
			});
	}
}