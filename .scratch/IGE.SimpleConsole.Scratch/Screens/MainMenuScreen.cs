namespace IGE.SimpleConsole.Scratch.Screens;

using IGE.SimpleConsole.Menu;
using IGE.SimpleConsole.Screen;

using Spectre.Console;

public class MainMenuScreen : ScreenBase
{
  private readonly SelectionPrompt<Option> menu = new SelectionPrompt<Option>()
    .Title($"[springgreen2]Main Menu[/]");

  private readonly ScreenManager screenManager;

  public MainMenuScreen(ScreenManager screenManager)
    : base("Main Menu")
  {
    this.screenManager = screenManager;
  }

  public override void Initialize()
  {
    this.menu.AddChoice(new Option("Say Hi", () =>
    {
      AnsiConsole.WriteLine("Hi Grugg!!!");
      SimpleMessage.AnyKeyToContinue();
    }));

    this.menu.AddChoice(new Option("Go Back", () => this.screenManager.Previous()));

    base.Initialize();
  }

  public override void Print()
  {
    var selection = AnsiConsole.Prompt(menu);
    selection.CallBack.Invoke();
    base.Print();
  }
}
