namespace Iron_Bite.API.Features.Ingredients.Endpoints.Extensions;

public static class IngredientsEndpointRouteBuilderExtensions
{
	public static void RegisterIngredientsEndpoints(this IEndpointRouteBuilder routes)
	{
		var baseIngredientsRoute = routes.MapGroup("/ingredients");
		var singleIngredientRoute = baseIngredientsRoute.MapGroup("/{ingredientId:guid}");

		baseIngredientsRoute.MapGet("", IngredientsEndpoints.GetIngredientsAsync);
		baseIngredientsRoute.MapPost("", IngredientsEndpoints.CreateIngredientAsync);

		singleIngredientRoute.MapGet("", IngredientsEndpoints.GetIngredientByIdAsync).WithName("GetIngredient");
		singleIngredientRoute.MapPut("", IngredientsEndpoints.UpdateIngredientAsync);
		singleIngredientRoute.MapDelete("", IngredientsEndpoints.DeleteIngredientAsync);
	}
}