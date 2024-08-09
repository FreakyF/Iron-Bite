using Iron_Bite.API.Models;

namespace Iron_Bite.API.Features.IngredientsMeals.Dtos;

public class IngredientMealDto
{
	public required Guid MealId { get; init; }
	public required Guid IngredientId { get; init; }
	public required Quantity Quantity { get; init; }
}