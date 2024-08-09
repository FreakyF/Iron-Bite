using Iron_Bite.API.Features.Ingredients.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iron_Bite.API.Persistence.Configurations;

public class IngredientTypeConfiguration : IEntityTypeConfiguration<Ingredient>
{
	public void Configure(EntityTypeBuilder<Ingredient> builder)
	{
		builder
			.Property(i => i.Name)
			.HasMaxLength(100);
		builder
			.Property(i => i.Description)
			.HasMaxLength(500);
	}
}