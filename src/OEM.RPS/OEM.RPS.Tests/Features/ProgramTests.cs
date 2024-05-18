using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using OEM.RPS.Infrastructure;
using OEM.RPS.Infrastructure.Helpers;

namespace OEM.RPS.Tests.Features;

public class ProgramTests
{
	[Fact]
	public void Main()
	{
		// Arrange
		IConsoleWrapper consoleWrapper = Substitute.For<IConsoleWrapper>();
		IGameModeHelper gameModeHelper = Substitute.For<IGameModeHelper>();
		IGameHelper gameHelper = Substitute.For<IGameHelper>();

		Program.Services = new ServiceCollection()
			.AddSingleton(consoleWrapper)
			.AddSingleton(gameModeHelper)
			.AddSingleton(gameHelper)
			.BuildServiceProvider();

		// Act
		Program.Main([]);

		// Assert
		gameModeHelper.Received(1)
			.GetGameMode();
		gameHelper.Received(1)
			.PlayGame();
		consoleWrapper.Received(1)
			.ReadKey();
	}
}