using Iron_Bite.API.Entities;

namespace Iron_Bite.API.Features.Ingredients.Entities;

public class Ingredient : BaseEntity
{
	public required string Name { get; init; }
	public string? Description { get; init; }
}