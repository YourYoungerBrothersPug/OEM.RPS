global using Colour = System.ConsoleColor;

namespace OEM.RPS.Infrastructure;

public interface IConsoleWrapper
{
	public void Clear();

	public ConsoleKeyInfo ReadKey();
	public string? ReadLine(Colour? colour = null);

	public void Write(string? input = null, Colour? colour = null);
	public void WriteLine(string? input = null, Colour? colour = null);
}

public class ConsoleWrapper : IConsoleWrapper
{
	public void Clear()
		=> Console.Clear();

	public ConsoleKeyInfo ReadKey()
		=> Console.ReadKey();

	public string? ReadLine(Colour? colour = null)
	{
		if (colour is not null)
			Console.ForegroundColor = colour.Value;

		return Console.ReadLine()?.Trim();
	}


	public void Write(string? input = null, Colour? colour = null)
	{
		if (colour is not null)
			Console.ForegroundColor = colour.Value;

		Console.Write(input);
	}

	public void WriteLine(string? input = null, Colour? colour = null)
		=> Write(input + "\r\n", colour);
}