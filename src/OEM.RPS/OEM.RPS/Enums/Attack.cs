using OEM.RPS.Models.Attributes;

namespace OEM.RPS.Enums;

// https://bigbangtheory.fandom.com/wiki/Rock,_Paper,_Scissors,_Lizard,_Spock
public enum Attack
{
	[WinsAgainst(Lizard, Scissors)]
	Rock,
	[WinsAgainst(Rock, Spock)]
	Paper,
	[WinsAgainst(Paper, Lizard)]
	Scissors,
	[WinsAgainst(Spock, Paper)]
	Lizard,
	[WinsAgainst(Scissors, Rock)]
	Spock
}