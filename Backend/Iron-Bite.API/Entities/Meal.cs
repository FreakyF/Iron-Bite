namespace Iron_Bite.API.Entities;

public class Meal : BaseEntity
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required string Instruction { get; set; }
}