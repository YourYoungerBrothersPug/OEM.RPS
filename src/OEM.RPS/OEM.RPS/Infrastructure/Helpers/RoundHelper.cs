using EnumsNET;
using OEM.RPS.Enums;
using OEM.RPS.Extensions;
using OEM.RPS.Infrastructure.Helpers.Base;
using OEM.RPS.Models.Attributes;

namespace OEM.RPS.Infrastructure.Helpers;

public interface IRoundHelper
{
	public Outcome PlayRound();
}

public class RoundHelper(IGameModeHelper gameModeHelper) : InputHelper, IRoundHelper
{
	private readonly Random _random = new();
	private readonly Attack[] _attacks = [.. Enum.GetValues<Attack>()
		.Where(a => gameModeHelper.BigBang || !a.HasAttribute<Attack, BigBangAttribute>())];

	private Attack? _userLastAttack;

	public Outcome PlayRound()
	{
		string question = $"What attack do you want to use?\r\n{string.Join("\r\n", _attacks.Select(a => $"{(int)a}) {a}"))}\r\n";
		Attack userAttack = InputAttack(question);
		Attack aiAttack = gameModeHelper.LastMove && _userLastAttack is not null
			? _userLastAttack.Value
			: _attacks[_random.Next(_attacks.Length)];

		_userLastAttack = userAttack;

		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine();
		foreach (Attack attack in _attacks)
		{
			Console.WriteLine($"{attack}...");
			Thread.Sleep(1000);
		}

		Console.Write("\r\nYou used ");
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine(userAttack.ToString().ToLower());
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write("The AI used ");
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine(aiAttack.ToString().ToLower());

		if (userAttack == aiAttack)
			return Outcome.Draw;

		WinsAgainstAttribute userWinsAgainst = userAttack.GetAttributes()!.Get<WinsAgainstAttribute>()!;

		return userWinsAgainst.WinsAgainst.Contains(aiAttack)
			? Outcome.UserWon
			: Outcome.UserLost;
	}
}