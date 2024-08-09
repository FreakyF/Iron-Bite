using Iron_Bite.API.Features.Nutrients.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iron_Bite.API.Persistence.Configurations;

public class NutrientTypeConfiguration : IEntityTypeConfiguration<Nutrient>
{
	public void Configure(EntityTypeBuilder<Nutrient> builder)
	{
		builder
			.Property(n => n.Protein)
			.HasPrecision(5, 2);
		builder
			.Property(n => n.Carbohydrates)
			.HasPrecision(5, 2);
		builder
			.Property(n => n.Fats)
			.HasPrecision(5, 2);
	}
}