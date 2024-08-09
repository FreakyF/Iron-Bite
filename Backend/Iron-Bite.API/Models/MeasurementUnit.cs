using System.Diagnostics.CodeAnalysis;

namespace Iron_Bite.API.Models;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum MeasurementUnit
{
	Kilogram,
	Gram,
	Piece,
	Liter,
	Milliliter,
	Cup,
	Spoon,
	Pinch
}