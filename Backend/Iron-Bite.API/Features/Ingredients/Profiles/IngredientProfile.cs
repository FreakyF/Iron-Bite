using AutoMapper;
using Iron_Bite.API.Features.Ingredients.Dtos;
using Iron_Bite.API.Features.Ingredients.Entities;

namespace Iron_Bite.API.Features.Ingredients.Profiles;

public class IngredientProfile : Profile
{
	public IngredientProfile()
	{
		CreateMap<Ingredient, IngredientDto>();
	}
}