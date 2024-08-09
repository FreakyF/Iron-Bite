using Iron_Bite.API.Entities;

namespace Iron_Bite.API.Features.Meals.Entities;

public class Meal : BaseEntity
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required string Instruction { get; set; }
}