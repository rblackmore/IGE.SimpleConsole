namespace IGE.SimpleConsole.Scratch.Screens;

using IGE.SimpleConsole.Screen;

using Spectre.Console;

public class TitleScreen : ScreenBase
{
  private readonly ScreenManager screenManager;

  public TitleScreen(ScreenManager screenManager)
    : base("Title Screen")
  {
    this.screenManager = screenManager;
  }

  public override async Task PrintAsync(CancellationToken token)
  {
    AnsiConsole.MarkupLine("[red]Welcome to Test App[/]");
    SimpleMessage.AnyKeyToContinue();

    await this.screenManager.SetScreenAsync<MainMenuScreen>(token);

    await base.PrintAsync(token);
  }

}
