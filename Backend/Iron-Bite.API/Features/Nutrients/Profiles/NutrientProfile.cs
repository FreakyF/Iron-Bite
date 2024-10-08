﻿using AutoMapper;
using Iron_Bite.API.Features.Nutrients.Dtos;
using Iron_Bite.API.Features.Nutrients.Entities;

namespace Iron_Bite.API.Features.Nutrients.Profiles;

// ReSharper disable once UnusedType.Global
public class NutrientProfile : Profile
{
	public NutrientProfile()
	{
		CreateMap<Nutrient, NutrientDto>();
	}
}