using Iron_Bite.API.Features.Ingredients.Entities;
using Iron_Bite.API.Features.IngredientsMeals.Entities;
using Iron_Bite.API.Features.Meals.Entities;
using Iron_Bite.API.Features.Nutrients.Entities;
using Iron_Bite.API.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Iron_Bite.API.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<Ingredient> Ingredients { get; init; } = null!;
	public DbSet<Meal> Meals { get; init; } = null!;
	public DbSet<Nutrient> Nutrients { get; init; } = null!;
	public DbSet<IngredientMeal> IngredientsMeals { get; init; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		new MealEntityTypeConfiguration().Configure(modelBuilder.Entity<Meal>());
		new IngredientTypeConfiguration().Configure(modelBuilder.Entity<Ingredient>());
		new NutrientTypeConfiguration().Configure(modelBuilder.Entity<Nutrient>());
		new IngredientMealTypeConfiguration().Configure(modelBuilder.Entity<IngredientMeal>());
	}
}