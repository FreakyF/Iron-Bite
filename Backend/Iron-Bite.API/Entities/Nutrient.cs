namespace Iron_Bite.API.Entities;

public class Nutrient : BaseEntity
{
	public required Guid IngredientId { get; init; }
	public required Ingredient Ingredient { get; init; }
	public required decimal Protein { get; set; }
	public required decimal Carbohydrates { get; set; }
	public required decimal Fats { get; set; }
}