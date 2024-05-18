using OEM.RPS.Enums;
using OEM.RPS.Infrastructure.Helpers.Base;

namespace OEM.RPS.Infrastructure.Helpers;

public interface IGameHelper
{
	public void PlayGame();
}

public class GameHelper(IRoundHelper roundHelper) : InputHelper, IGameHelper
{
	public void PlayGame()
	{
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

			if (!InputBool("\r\nPlay again? "))
				break;

			Console.Clear();
		}
	}
}