namespace Iron_Bite.API.Features.IngredientsMeals.Endpoints.Extensions;

public static class IngredientsMealsEndpointRouteBuilderExtensions
{
	public static void RegisterIngredientsMealsEndpoints(this IEndpointRouteBuilder routes)
	{
		var baseIngredientsMealsRoute = routes.MapGroup("/ingredientsmeals");
		var singleIngredientMealRoute = baseIngredientsMealsRoute.MapGroup("/{ingredientMealId:guid}");

		baseIngredientsMealsRoute.MapGet("", IngredientsMealsMealsEndpoints.GetIngredientsMealsMealsAsync);
		baseIngredientsMealsRoute.MapPost("", IngredientsMealsMealsEndpoints.CreateIngredientMealAsync);

		singleIngredientMealRoute.MapGet("", IngredientsMealsMealsEndpoints.GetIngredientMealByIdAsync).WithName("GetIngredientMeal");
		singleIngredientMealRoute.MapPut("", IngredientsMealsMealsEndpoints.UpdateIngredientMealAsync);
		singleIngredientMealRoute.MapDelete("", IngredientsMealsMealsEndpoints.DeleteIngredientMealAsync);
	}
}