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

app.MapGet("/meals", async (AppDbContext appDbContext) => await appDbContext.Meals.ToListAsync());
app.MapGet("/ingredients", async (AppDbContext appDbContext) => await appDbContext.Ingredients.ToListAsync());
app.MapGet("/nutrients", async (AppDbContext appDbContext) => await appDbContext.Nutrients.ToListAsync());
app.MapGet("/ingredientsmeals",
	async (AppDbContext appDbContext) => await appDbContext.IngredientsMeals.ToListAsync());

app.MapGet("/meals/{mealId:guid}", async (AppDbContext appDbContext, Guid mealId) =>
{
	return await appDbContext.Meals
		.FirstOrDefaultAsync(m => m.Id == mealId);
});

app.MapGet("/ingredients/{ingredientId:guid}", async (AppDbContext appDbContext, Guid ingredientId) =>
{
	return await appDbContext.Ingredients
		.FirstOrDefaultAsync(i => i.Id == ingredientId);
});

app.MapGet("/nutrients/{nutrientId:guid}", async (AppDbContext appDbContext, Guid nutrientId) =>
{
	return await appDbContext.Nutrients
		.FirstOrDefaultAsync(n => n.Id == nutrientId);
});

app.MapGet("/ingredientsmeals/{ingredientmealId:guid}", async (AppDbContext appDbContext, Guid ingredientmealId) =>
{
	return await appDbContext.IngredientsMeals
		.FirstOrDefaultAsync(i => i.Id == ingredientmealId);
});

await app.RunAsync();