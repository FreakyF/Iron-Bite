using AutoMapper;
using Iron_Bite.API.Features.Meals.Dtos;
using Iron_Bite.API.Features.Meals.Entities;

namespace Iron_Bite.API.Features.Meals.Profiles;

public class MealProfile : Profile
{
	public MealProfile()
	{
		CreateMap<Meal, MealDto>();
	}
}