namespace Iron_Bite.API.Entities;

public class Ingredient : BaseEntity
{
	public required string Name { get; set; }
	public string? Description { get; set; }
}