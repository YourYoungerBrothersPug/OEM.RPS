using OEM.RPS.Enums;

namespace OEM.RPS.Models.Attributes;

public class WinsAgainstAttribute(params Attack[] winsAgainst) : Attribute
{
	public Attack[] WinsAgainst { get; } = winsAgainst;
}