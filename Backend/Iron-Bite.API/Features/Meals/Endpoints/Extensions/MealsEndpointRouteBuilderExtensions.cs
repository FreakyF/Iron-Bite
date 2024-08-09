namespace Iron_Bite.API.Features.Meals.Endpoints.Extensions;

public static class MealsEndpointRouteBuilderExtensions
{
	public static void RegisterMealsEndpoints(this IEndpointRouteBuilder routes)
	{
		var baseMealsRoute = routes.MapGroup("/meals");
		var singleMealRoute = baseMealsRoute.MapGroup("/{mealId:guid}");

		baseMealsRoute.MapGet("", MealsEndpoints.GetMealsAsync);
		baseMealsRoute.MapPost("", MealsEndpoints.CreateMealAsync);

		singleMealRoute.MapGet("", MealsEndpoints.GetMealByIdAsync).WithName("GetMeal");
		singleMealRoute.MapPut("", MealsEndpoints.UpdateMealAsync);
		singleMealRoute.MapDelete("", MealsEndpoints.DeleteMealAsync);
	}
}