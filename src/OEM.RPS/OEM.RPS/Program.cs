using OEM.RPS.Enums;
using OEM.RPS.Infrastructure;

namespace OEM.RPS;

public class Program
{
	public static void Main(string[] args)
	{
		// TODO Write Instructions

		IGameModeHelper gameModeHelper = new GameModeHelper();
		GameMode gameMode = gameModeHelper.GetGameMode();

		IRoundHelper roundHelper = new RoundHelper(gameMode);

		while (true)
		{
			switch (roundHelper.PlayRound())
			{
				case Outcome.UserWon:
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("You won");
					break;
				case Outcome.Draw:
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("You drew");
					break;
				case Outcome.UserLost:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("You lost");
					break;
			}

			if (!roundHelper.InputBool("\r\nPlay again? "))
				break;
			Console.Clear();
		}

		Console.ForegroundColor = ConsoleColor.White;
		Console.Write("\r\nPress any key to exit.");
		Console.ReadKey();
	}
}