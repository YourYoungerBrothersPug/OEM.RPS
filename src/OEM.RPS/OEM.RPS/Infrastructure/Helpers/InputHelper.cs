using OEM.RPS.Enums;

namespace OEM.RPS.Infrastructure.Helpers;

public interface IInputHelper
{
	public bool InputBool(string question);
	public Attack InputAttack(string question);
}

public class InputHelper(IConsoleWrapper console) : IInputHelper
{
	private string? GetInput(string question)
	{
		console.Write(question, Colour.White);
		return console.ReadLine(Colour.Yellow);
	}

	public bool InputBool(string question)
	{
		while (true)
		{
			string? input = GetInput(question);

			if (string.IsNullOrWhiteSpace(input))
				continue;

			switch (input.ToLower())
			{
				case "yes" or "y" or "true":
					return true;
				case "no" or "n" or "false":
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