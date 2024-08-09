using AutoMapper;
using Iron_Bite.API.Features.Nutrients.Dtos;
using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Iron_Bite.API.Features.Nutrients.Endpoints;

public static class NutrientsEndpoints
{
	public static void MapNutrientsEndpoints(this WebApplication app)
	{
		app.MapGet("/nutrients",
			async (AppDbContext appDbContext, IMapper mapper) =>
			{
				TypedResults.Ok(mapper.Map<IEnumerable<NutrientDto>>(await appDbContext.Nutrients.ToListAsync()));
			});


		app.MapGet("/nutrients/{nutrientId:guid}",
			async (AppDbContext appDbContext, IMapper mapper, Guid nutrientId) =>
			{
				TypedResults.Ok(
					mapper.Map<NutrientDto>(await appDbContext.Nutrients.FirstOrDefaultAsync(n => n.Id == nutrientId)));
			});
	}
}