namespace Iron_Bite.API.Features.Nutrients.Endpoints.Extensions;

public static class NutrientsEndpointRouteBuilderExtensions
{
	public static void RegisterNutrientsEndpoints(this IEndpointRouteBuilder routes)
	{
		var baseNutrientsRoute = routes.MapGroup("/nutrients");
		var singleNutrientRoute = baseNutrientsRoute.MapGroup("/{nutrientId:guid}");

		baseNutrientsRoute.MapGet("", NutrientsEndpoints.GetNutrientsAsync);
		baseNutrientsRoute.MapPost("", NutrientsEndpoints.CreateNutrientAsync);

		singleNutrientRoute.MapGet("", NutrientsEndpoints.GetNutrientByIdAsync).WithName("GetNutrient");
		singleNutrientRoute.MapPut("", NutrientsEndpoints.UpdateNutrientAsync);
		singleNutrientRoute.MapDelete("", NutrientsEndpoints.DeleteNutrientAsync);
	}
}