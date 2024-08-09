using AutoMapper;
using Iron_Bite.API.Features.Ingredients.Dtos;
using Iron_Bite.API.Features.Ingredients.Entities;

namespace Iron_Bite.API.Features.Ingredients.Profiles;

// ReSharper disable once UnusedType.Global
public class IngredientProfile : Profile
{
	public IngredientProfile()
	{
		CreateMap<Ingredient, IngredientDto>();
	}
}