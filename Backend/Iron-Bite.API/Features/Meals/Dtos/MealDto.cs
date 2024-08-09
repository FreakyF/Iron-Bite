namespace Iron_Bite.API.Features.Meals.Dtos;

public class MealDto
{
	public required string Name { get; init; }
	public string? Description { get; init; }
	public required string Instruction { get; init; }
}