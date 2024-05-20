namespace OEM.RPS.Infrastructure.Helpers;

public interface IGameModeHelper
{
	public bool LastMove { get; }
	public bool BigBang { get; }

	public void GetGameMode();
}

public class GameModeHelper(IConsoleWrapper console, IInputHelper inputHelper) : IGameModeHelper
{
	public bool LastMove { get; private set; }
	public bool BigBang { get; private set; }

	public void GetGameMode()
	{
		LastMove = inputHelper.InputBool("Should the AI play your last move? ");
		BigBang = inputHelper.InputBool("Do you want to add lizard and spock from the Big Bang Theory? ");

		console.Clear();
		console.WriteLine("Game Modes Selected", Colour.White);
		console.WriteLine("-------------------", Colour.Gray);
		console.Write("Last Move AI: ", Colour.White);
		console.WriteLine(LastMove.ToString(), Colour.Gray);
		console.Write("Big Bang: ", Colour.White);
		console.WriteLine(BigBang.ToString(), Colour.Gray);
		console.WriteLine();
	}
}