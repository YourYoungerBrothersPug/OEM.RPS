using Microsoft.Extensions.DependencyInjection;
using OEM.RPS.Infrastructure.Helpers;

namespace OEM.RPS;

public class Program
{
	public static IServiceProvider Services { get; set; } = new ServiceCollection()
		.AddSingleton<IGameModeHelper, GameModeHelper>()
		.AddSingleton<IGameHelper, GameHelper>()
		.AddSingleton<IRoundHelper, RoundHelper>()
		.BuildServiceProvider();

	public static void Main(string[] args)
	{
		Services.GetRequiredService<IGameModeHelper>()
			.GetGameMode();
		Services.GetRequiredService<IGameHelper>()
			.PlayGame();

		Console.ForegroundColor = ConsoleColor.White;
		Console.Write("\r\nPress any key to exit.");
		Console.ReadKey();
	}
}