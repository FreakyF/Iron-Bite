namespace Iron_Bite.API.Features.Nutrients.Dtos;

public class NutrientDto
{
	public required Guid IngredientId { get; init; }
	public required decimal Protein { get; init; }
	public required decimal Carbohydrates { get; init; }
	public required decimal Fats { get; init; }
}