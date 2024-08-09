using Iron_Bite.API.Features.Ingredients.Endpoints.Extensions;
using Iron_Bite.API.Features.IngredientsMeals.Endpoints.Extensions;
using Iron_Bite.API.Features.Meals.Endpoints.Extensions;
using Iron_Bite.API.Features.Nutrients.Endpoints.Extensions;
using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o =>
{
	o.UseSqlServer(builder.Configuration.GetConnectionString("IronBiteDb"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddProblemDetails();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) app.UseExceptionHandler();

app.UseHttpsRedirection();
app.RegisterMealsEndpoints();
app.RegisterIngredientsEndpoints();
app.RegisterNutrientsEndpoints();
app.RegisterIngredientsMealsEndpoints();

await app.RunAsync();