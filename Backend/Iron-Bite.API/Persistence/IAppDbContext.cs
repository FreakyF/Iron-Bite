using Iron_Bite.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Iron_Bite.API.Persistence;

public interface IAppDbContext
{
	public DbSet<Ingredient> Ingredients { get; set; }
	public DbSet<Meal> Meals { get; set; }
	public DbSet<Nutrient> Nutrients { get; set; }
	public DbSet<IngredientMeal> IngredientMeals { get; set; }
}