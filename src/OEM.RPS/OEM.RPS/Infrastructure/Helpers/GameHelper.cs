using OEM.RPS.Enums;

namespace OEM.RPS.Infrastructure.Helpers;

public interface IGameHelper
{
	public void PlayGame();
}

public class GameHelper(IConsoleWrapper console, IRoundHelper roundHelper, IInputHelper inputHelper) : IGameHelper
{
	public void PlayGame()
	{
		while (true)
		{
			switch (roundHelper.PlayRound())
			{
				case Outcome.UserWon:
					console.WriteLine("You won", Colour.Green);
					break;
				case Outcome.Draw:
					console.WriteLine("You drew", Colour.Yellow);
					break;
				case Outcome.UserLost:
					console.WriteLine("You lost", Colour.Red);
					break;
			}

			if (!inputHelper.InputBool("\r\nPlay again? "))
				break;

			console.Clear();
		}
	}
}