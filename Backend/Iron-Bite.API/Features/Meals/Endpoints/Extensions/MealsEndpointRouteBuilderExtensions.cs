namespace Iron_Bite.API.Features.Meals.Endpoints.Extensions;

public static class MealsEndpointRouteBuilderExtensions
{
	public static void RegisterMealsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
	{
		var mealsEndpoints = endpointRouteBuilder.MapGroup("/meals");
		var mealsWithGuidIdEndpoints = endpointRouteBuilder.MapGroup("/meals/{mealId:guid}");

		mealsEndpoints.MapGet("", MealsEndpoints.GetMealsAsync);
		mealsWithGuidIdEndpoints.MapGet("", MealsEndpoints.GetMealByIdAsync);
		mealsEndpoints.MapPost("", MealsEndpoints.CreateMealAsync);
		mealsWithGuidIdEndpoints.MapPut("", MealsEndpoints.UpdateMealAsync);
		mealsWithGuidIdEndpoints.MapDelete("", MealsEndpoints.DeleteMealAsync);
	}
}