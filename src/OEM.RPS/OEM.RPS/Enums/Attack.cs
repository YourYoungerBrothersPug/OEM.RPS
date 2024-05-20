using OEM.RPS.Models.Attributes;

namespace OEM.RPS.Enums;

// https://bigbangtheory.fandom.com/wiki/Rock,_Paper,_Scissors,_Lizard,_Spock
public enum Attack
{
	[WinsAgainst(Lizard, Scissors)]
	Rock = 1,
	[WinsAgainst(Rock, Spock)]
	Paper = 2,
	[WinsAgainst(Paper, Lizard)]
	Scissors = 3,
	[BigBang]
	[WinsAgainst(Spock, Paper)]
	Lizard = 4,
	[BigBang]
	[WinsAgainst(Scissors, Rock)]
	Spock = 5
}