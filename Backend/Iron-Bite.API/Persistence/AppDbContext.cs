using Iron_Bite.API.Entities;
using Iron_Bite.API.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Iron_Bite.API.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options), IAppDbContext
{
    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<Meal> Meals { get; set; } = null!;
    public DbSet<Nutrient> Nutrients { get; set; } = null!;
    public DbSet<IngredientMeal> IngredientMeals { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Nutrient>()
            .Property(n => n.Carbohydrates)
            .HasPrecision(5, 2); 

        modelBuilder.Entity<Nutrient>()
            .Property(n => n.Fats)
            .HasPrecision(5, 2); 

        modelBuilder.Entity<Nutrient>()
            .Property(n => n.Protein)
            .HasPrecision(5, 2);

        modelBuilder.Entity<IngredientMeal>()
            .OwnsOne(i => i.Quantity, q =>
            {
                q.Property(p => p.Value)
                    .HasPrecision(5, 2);
            });
    }
}
