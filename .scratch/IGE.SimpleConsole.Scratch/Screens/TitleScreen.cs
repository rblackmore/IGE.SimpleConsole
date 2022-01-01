namespace IGE.SimpleConsole.Scratch.Screens;

using IGE.SimpleConsole.Screen;

using Spectre.Console;

public class TitleScreen : ScreenBase
{
  private readonly ScreenManager screenManager;

  public TitleScreen(ScreenManager screenManager)
  {
    this.screenManager = screenManager;
  }

  public override void Print()
  {
    AnsiConsole.MarkupLine("[red]Welcome to Test App[/]");
    SimpleMessage.AnyKeyToContinue();

    this.screenManager.SetScreen<MainMenuScreen>();

    base.Print();
  }

}
