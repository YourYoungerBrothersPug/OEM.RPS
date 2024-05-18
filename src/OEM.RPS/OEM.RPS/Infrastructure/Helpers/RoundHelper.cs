using EnumsNET;
using OEM.RPS.Enums;
using OEM.RPS.Extensions;
using OEM.RPS.Models.Attributes;

namespace OEM.RPS.Infrastructure.Helpers;

public interface IRoundHelper
{
	public Outcome PlayRound();
}

public class RoundHelper(IConsoleWrapper console, IGameModeHelper gameModeHelper, IInputHelper inputHelper) : IRoundHelper
{
	private readonly Random _random = new();
	private readonly Attack[] _attacks = [.. Enum.GetValues<Attack>()
		.Where(a => gameModeHelper.BigBang || !a.HasAttribute<Attack, BigBangAttribute>())];

	private Attack? _userLastAttack;

	public Outcome PlayRound()
	{
		string question = $"What attack do you want to use?\r\n{string.Join("\r\n", _attacks.Select(a => $"{(int)a}) {a}"))}\r\n";
		Attack userAttack = inputHelper.InputAttack(question);
		Attack aiAttack = gameModeHelper.LastMove && _userLastAttack is not null
			? _userLastAttack.Value
			: _attacks[_random.Next(_attacks.Length)];

		_userLastAttack = userAttack;

		console.WriteLine(null, Colour.White);
		foreach (Attack attack in _attacks)
		{
			console.WriteLine($"{attack}...");
			Thread.Sleep(1000);
		}

		console.Write("\r\nYou used ");
		console.WriteLine(userAttack.ToString().ToLower(), Colour.Gray);
		console.Write("The AI used ", Colour.White);
		console.WriteLine(aiAttack.ToString().ToLower(), Colour.Gray);

		if (userAttack == aiAttack)
			return Outcome.Draw;

		WinsAgainstAttribute userWinsAgainst = userAttack.GetAttributes()!.Get<WinsAgainstAttribute>()!;

		return userWinsAgainst.WinsAgainst.Contains(aiAttack)
			? Outcome.UserWon
			: Outcome.UserLost;
	}
}