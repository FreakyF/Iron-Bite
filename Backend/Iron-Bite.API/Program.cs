using AutoMapper;
using Iron_Bite.API.Features.Ingredients.Dtos;
using Iron_Bite.API.Features.IngredientsMeals.Dtos;
using Iron_Bite.API.Features.Meals.Dtos;
using Iron_Bite.API.Features.Nutrients.Dtos;
using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o =>
{
	o.UseSqlServer(builder.Configuration.GetConnectionString("IronBiteDb"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/meals",
	async (AppDbContext appDbContext, IMapper mapper, string? name) =>
		mapper.Map<IEnumerable<MealDto>>(await appDbContext.Meals
			.Where(m => string.IsNullOrEmpty(name) || m.Name.Contains(name))
			.ToListAsync()));

app.MapGet("/ingredients",
	async (AppDbContext appDbContext, IMapper mapper, string? name) =>
		mapper.Map<IEnumerable<IngredientDto>>(await appDbContext.Ingredients
			.Where(i => string.IsNullOrEmpty(name) || i.Name.Contains(name))
			.ToListAsync()));

app.MapGet("/nutrients",
	async (AppDbContext appDbContext, IMapper mapper) =>
		mapper.Map<IEnumerable<NutrientDto>>(await appDbContext.Nutrients
			.ToListAsync()));

app.MapGet("/ingredientsmeals",
	async (AppDbContext appDbContext, IMapper mapper) =>
		mapper.Map<IEnumerable<IngredientMealDto>>(await appDbContext.IngredientsMeals
			.ToListAsync()));

app.MapGet("/meals/{mealId:guid}",
	async (AppDbContext appDbContext, IMapper mapper, Guid mealId) =>
		mapper.Map<MealDto>(await appDbContext.Meals
			.FirstOrDefaultAsync(m => m.Id == mealId)));

app.MapGet("/ingredients/{ingredientId:guid}",
	async (AppDbContext appDbContext, IMapper mapper, Guid ingredientId) =>
		mapper.Map<IngredientDto>(await appDbContext.Ingredients
			.FirstOrDefaultAsync(i => i.Id == ingredientId)));

app.MapGet("/nutrients/{nutrientId:guid}",
	async (AppDbContext appDbContext, IMapper mapper, Guid nutrientId) =>
		mapper.Map<NutrientDto>(await appDbContext.Nutrients
			.FirstOrDefaultAsync(n => n.Id == nutrientId)));

app.MapGet("/ingredientsmeals/{ingredientmealId:guid}",
	async (AppDbContext appDbContext, IMapper mapper, Guid ingredientmealId) =>
		mapper.Map<IngredientMealDto>(await appDbContext.IngredientsMeals
			.FirstOrDefaultAsync(i => i.Id == ingredientmealId)));

await app.RunAsync();