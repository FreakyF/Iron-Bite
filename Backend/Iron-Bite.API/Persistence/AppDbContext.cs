using Iron_Bite.API.Entities;
using Microsoft.EntityFrameworkCore;

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

		modelBuilder.Entity<Ingredient>()
			.Property(i => i.Name)
			.HasMaxLength(100);
		modelBuilder.Entity<Ingredient>()
			.Property(i => i.Description)
			.HasMaxLength(500);

		modelBuilder.Entity<Meal>()
			.Property(m => m.Name)
			.HasMaxLength(100);
		modelBuilder.Entity<Meal>()
			.Property(m => m.Description)
			.HasMaxLength(500);
		modelBuilder.Entity<Meal>()
			.Property(m => m.Instruction)
			.HasMaxLength(2000);

		modelBuilder.Entity<IngredientMeal>()
			.OwnsOne(im => im.Quantity, q =>
			{
				q.Property(p => p.Value)
					.HasPrecision(5, 2);
			});

		modelBuilder.Entity<Nutrient>()
			.Property(n => n.Protein)
			.HasPrecision(5, 2);
		modelBuilder.Entity<Nutrient>()
			.Property(n => n.Carbohydrates)
			.HasPrecision(5, 2);
		modelBuilder.Entity<Nutrient>()
			.Property(n => n.Fats)
			.HasPrecision(5, 2);
	}
}