using OEM.RPS.Enums;
using OEM.RPS.Extensions;
using OEM.RPS.Models.Attributes;

namespace OEM.RPS.Infrastructure;

public interface IRoundHelper
{
	public Outcome PlayRound(GameMode gameMode);
}

public class RoundHelper : InputHelper, IRoundHelper
{
	public Outcome PlayRound(GameMode gameMode)
	{
		Attack[] availableAttacks = gameMode.BigBang
			? Enum.GetValues<Attack>()
			: [.. Enum.GetValues<Attack>()
				.Where(a => !a.HasAttribute<BigBangAttribute>())];

		Attack chosenAttack = InputAttack($"What attack do you want to use?\r\n{string.Join("\r\n", availableAttacks)}\r\n");

		foreach (Attack attack in availableAttacks)
		{
			Console.WriteLine($"{attack}...");
			Thread.Sleep(250);
		}

		// TODO Add Random AI Player
		// TODO Add Last Choice AI

		// TODO Determine outcome
		// TODO If the same, if I've won against
		return Outcome.Win;
	}
}