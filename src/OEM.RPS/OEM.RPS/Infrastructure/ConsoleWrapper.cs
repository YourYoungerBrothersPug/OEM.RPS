namespace OEM.RPS.Infrastructure;

public interface IConsoleWrapper
{
	public void ReadKey();
}

public class ConsoleWrapper : IConsoleWrapper
{
	public void ReadKey()
		=> Console.ReadKey();
}