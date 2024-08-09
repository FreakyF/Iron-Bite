using Iron_Bite.API.Entities;
using Iron_Bite.API.Features.Ingredients.Entities;
using Iron_Bite.API.Features.Meals.Entities;
using Iron_Bite.API.Models;

namespace Iron_Bite.API.Features.IngredientsMeals.Entities;

public class IngredientMeal : BaseEntity
{
	public required Guid MealId { get; init; }
	public required Meal Meal { get; init; }
	public required Guid IngredientId { get; init; }
	public required Ingredient Ingredient { get; init; }
	public required Quantity Quantity { get; init; }
}