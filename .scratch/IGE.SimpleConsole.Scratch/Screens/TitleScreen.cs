namespace IGE.SimpleConsole.Scratch.Screens;

using IGE.SimpleConsole.Components;
using IGE.SimpleConsole.Screen;

using Spectre.Console;

public class TitleScreen : ScreenBase
{
  private readonly ScreenManager screenManager;

  public TitleScreen(ScreenManager screenManager, SimpleConsoleApp app)
    : base(app)
  {
    this.ScreenTitle = new ScreenTitle("Title Screen");
    this.screenManager = screenManager;
  }

  public override async Task PrintAsync(CancellationToken token)
  {
    await base.PrintAsync(token);

    SimpleMessage.AnyKeyToContinue();

    await this.screenManager.SetScreenAsync<MainMenuScreen>(token);
  }
}
