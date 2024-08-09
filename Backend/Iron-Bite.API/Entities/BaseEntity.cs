namespace Iron_Bite.API.Entities;

public abstract class BaseEntity
{
	// ReSharper disable once UnusedAutoPropertyAccessor.Global
	public required Guid Id { get; init; }
}