using Iron_Bite.API.Features.Ingredients.Endpoints;
using Iron_Bite.API.Features.IngredientsMeals.Endpoints;
using Iron_Bite.API.Features.Meals.Endpoints;
using Iron_Bite.API.Features.Nutrients.Endpoints;
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

app.MapMealsEndpoints();
app.MapNutrientsEndpoints();
app.MapIngredientsEndpoints();
app.MapIngredientsMealsEndpoints();

await app.RunAsync();