using Iron_Bite.API.Entities;

namespace Iron_Bite.API.Features.Meals.Entities;

public class Meal : BaseEntity
{
	public required string Name { get; init; }
	public string? Description { get; init; }
	public required string Instruction { get; init; }
}