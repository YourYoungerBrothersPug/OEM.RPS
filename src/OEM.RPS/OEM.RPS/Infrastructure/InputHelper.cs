using OEM.RPS.Enums;

namespace OEM.RPS.Infrastructure;

public abstract class InputHelper
{
	private static string? GetInput(string question)
	{
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write(question);
		Console.ForegroundColor = ConsoleColor.Yellow;
		return Console.ReadLine();
	}

	public bool InputBool(string question)
	{
		while (true)
		{
			string? input = GetInput(question);

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

	public Attack InputAttack(string question)
	{
		while (true)
		{
			string? input = GetInput(question);

			if (string.IsNullOrWhiteSpace(input))
				continue;

			if (Enum.TryParse(input, true, out Attack attack) && Enum.IsDefined(attack))
				return attack;
		}
	}
}