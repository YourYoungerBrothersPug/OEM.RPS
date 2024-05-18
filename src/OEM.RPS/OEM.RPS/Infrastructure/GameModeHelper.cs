namespace OEM.RPS.Infrastructure;

public interface IGameModeHelper
{
	public GameMode GetGameMode();
}

public class GameModeHelper : InputHelper, IGameModeHelper
{
	public GameMode GetGameMode()
	{
		const string lastMoveQuestion = "Should the AI play your last move? ";
		const string bigBangQuestion = "Do you want to add lizard and spock from the Big Bang Theory? ";

		GameMode gameMode = (InputBool(lastMoveQuestion), InputBool(bigBangQuestion));

		Console.Clear();
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine("Game Modes Selected");
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine("-------------------");
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write("Last Move AI: ");
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine(gameMode.LastMove);
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write("Big Bang: ");
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine(gameMode.BigBang);
		Console.WriteLine();

		return gameMode;
	}
}