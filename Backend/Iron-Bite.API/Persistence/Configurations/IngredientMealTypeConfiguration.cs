using Iron_Bite.API.Features.IngredientsMeals.Entities;
using Iron_Bite.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iron_Bite.API.Persistence.Configurations;

public class IngredientMealTypeConfiguration : IEntityTypeConfiguration<IngredientMeal>
{
	public void Configure(EntityTypeBuilder<IngredientMeal> builder)
	{
		builder
			.OwnsOne(im => im.Quantity, q =>
			{
				q.Property(p => p.Value)
					.HasPrecision(5, 2);

				q.Property(p => p.Unit)
					.HasConversion(
						v => (int)v,
						v => Enum.IsDefined(typeof(MeasurementUnit), v) ? (MeasurementUnit)v : default
					);
			});
	}
}