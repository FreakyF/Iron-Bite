using Iron_Bite.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Iron_Bite.API.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options), IAppDbContext
{
    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<Meal> Meals { get; set; } = null!;
    public DbSet<Nutrient> Nutrients { get; set; } = null!;
    public DbSet<IngredientMeal> IngredientMeals { get; set; } = null!;
}
