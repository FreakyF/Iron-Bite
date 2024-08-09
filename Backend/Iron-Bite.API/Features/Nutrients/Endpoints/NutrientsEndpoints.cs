using AutoMapper;
using Iron_Bite.API.Features.Nutrients.Dtos;
using Iron_Bite.API.Features.Nutrients.Entities;
using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Iron_Bite.API.Features.Nutrients.Endpoints;

public static class NutrientsEndpoints
{
	public static async Task<IResult> GetNutrientsAsync(AppDbContext appDbContext, IMapper mapper)
	{
		var nutrients = await appDbContext.Nutrients
			.AsNoTracking()
			.ToListAsync();
		return Results.Ok(mapper.Map<IEnumerable<NutrientDto>>(nutrients));
	}

	public static async Task<IResult> GetNutrientByIdAsync(AppDbContext appDbContext, IMapper mapper, Guid nutrientId)
	{
		var nutrient = await appDbContext.Nutrients.FindAsync(nutrientId);
		if (nutrient is null) return TypedResults.NotFound();
		return TypedResults.Ok(mapper.Map<NutrientDto>(nutrient));
	}

	public static async Task<IResult> CreateNutrientAsync(AppDbContext appDbContext, IMapper mapper,
		NutrientDto nutrientDto)
	{
		var nutrient = mapper.Map<Nutrient>(nutrientDto);
		await appDbContext.Nutrients.AddAsync(nutrient);
		await appDbContext.SaveChangesAsync();

		return Results.CreatedAtRoute("GetNutrient", new { nutrientId = nutrient.Id },
			mapper.Map<NutrientDto>(nutrient));
	}

	public static async Task<IResult> UpdateNutrientAsync(AppDbContext appDbContext, IMapper mapper, Guid nutrientId,
		NutrientDto nutrientDto)
	{
		var nutrient = await appDbContext.Nutrients.FindAsync(nutrientId);
		if (nutrient is null) return TypedResults.NotFound();

		mapper.Map(nutrientDto, nutrient);
		await appDbContext.SaveChangesAsync();

		return TypedResults.NoContent();
	}

	public static async Task<IResult> DeleteNutrientAsync(AppDbContext appDbContext, IMapper mapper, Guid nutrientId)
	{
		var nutrient = await appDbContext.Nutrients.FindAsync(nutrientId);
		if (nutrient is null) return TypedResults.NotFound();

		appDbContext.Nutrients.Remove(nutrient);
		await appDbContext.SaveChangesAsync();
		return TypedResults.NoContent();
	}
}