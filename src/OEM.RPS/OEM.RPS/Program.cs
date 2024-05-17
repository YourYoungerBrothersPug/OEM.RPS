using GameMode = (bool LastMove, bool BigBang);

namespace OEM.RPS;

public class Program
{
	public static void Main(string[] args)
	{
		GameMode gameMode = GetGameMode();
		Console.ReadKey();
	}

	public static GameMode GetGameMode()
	{
		const string lastMoveQuestion = "Should the AI play your last move? ";
		const string bigBangQuestion = "Add lizard and spock from the Big Bang Theory? ";

		GameMode gameMode = (InputBool(lastMoveQuestion), InputBool(bigBangQuestion));

		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine("\r\nGame Modes Selected");
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

	public static bool InputBool(string question)
	{
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(question);
			Console.ForegroundColor = ConsoleColor.Yellow;
			string? input = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(input))
				continue;

			switch (input.Trim().ToLower())
			{
				case "yes" or "y" or "true" or "1":
					return true;
				case "no" or "n" or "false" or "0":
					return false;
			}
		}
	}
}