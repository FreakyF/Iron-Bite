using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(o =>
{
	o.UseSqlServer(builder.Configuration.GetConnectionString("IronBiteDb"));
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/meals", async (IAppDbContext appDbContext) => await appDbContext.Meals.ToListAsync());

app.MapGet("/meals/{mealId:guid}", async (IAppDbContext appDbContext, Guid mealId) =>
{
	return await appDbContext.Meals
		.FirstOrDefaultAsync(m => m.Id == mealId);
});

await app.RunAsync();