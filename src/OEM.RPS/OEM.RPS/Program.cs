using OEM.RPS.Infrastructure;

namespace OEM.RPS;

public class Program
{
	public static void Main(string[] args)
	{
		IGameModeHelper gameModeHelper = new GameModeHelper();
		GameMode gameMode = gameModeHelper.GetGameMode();

		IRoundHelper roundHelper = new RoundHelper();

		while (true)
		{
			roundHelper.PlayRound(gameMode);
			break;
		}

		Console.ReadKey();
	}
}