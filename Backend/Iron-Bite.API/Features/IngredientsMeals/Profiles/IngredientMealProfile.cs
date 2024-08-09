using AutoMapper;
using Iron_Bite.API.Features.IngredientsMeals.Dtos;
using Iron_Bite.API.Features.IngredientsMeals.Entities;

namespace Iron_Bite.API.Features.IngredientsMeals.Profiles;

public class IngredientMealProfile : Profile
{
	public IngredientMealProfile()
	{
		CreateMap<IngredientMeal, IngredientMealDto>();
	}
}