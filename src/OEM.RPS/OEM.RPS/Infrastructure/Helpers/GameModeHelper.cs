using OEM.RPS.Infrastructure.Helpers.Base;

namespace OEM.RPS.Infrastructure.Helpers;

public interface IGameModeHelper
{
	public bool LastMove { get; }
	public bool BigBang { get; }

	public void GetGameMode();
}

public class GameModeHelper : InputHelper, IGameModeHelper
{
	public bool LastMove { get; private set; }
	public bool BigBang { get; private set; }

	public void GetGameMode()
	{
		LastMove = InputBool("Should the AI play your last move? ");
		BigBang = InputBool("Do you want to add lizard and spock from the Big Bang Theory? ");

		Console.Clear();
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine("Game Modes Selected");
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine("-------------------");
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write("Last Move AI: ");
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine(LastMove);
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write("Big Bang: ");
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine(BigBang);
		Console.WriteLine();
	}
}