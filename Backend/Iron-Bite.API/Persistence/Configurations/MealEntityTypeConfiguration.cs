using Iron_Bite.API.Features.Meals.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iron_Bite.API.Persistence.Configurations;

public class MealEntityTypeConfiguration : IEntityTypeConfiguration<Meal>
{
	public void Configure(EntityTypeBuilder<Meal> builder)
	{
		builder
			.Property(m => m.Name)
			.HasMaxLength(100);
		builder
			.Property(m => m.Description)
			.HasMaxLength(500);
		builder
			.Property(m => m.Instruction)
			.HasMaxLength(5000);
	}
}