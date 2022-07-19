namespace IGE.SimpleConsole.Scratch.Screens;

using IGE.SimpleConsole.Components;
using IGE.SimpleConsole.Screen;

using Spectre.Console;

public class MainMenuScreen : ScreenBase
{
  private readonly SelectionPrompt<Option> menu = new SelectionPrompt<Option>()
    .Title($"[springgreen2]Main Prompt[/]");

  private readonly ScreenManager screenManager;

  public MainMenuScreen(ScreenManager screenManager, SimpleConsoleApp app)
    : base(app)
  {
    this.ScreenTitle = new ScreenTitle("Main Menu");
    this.screenManager = screenManager;
  }

  public override async Task InitializeAsync(CancellationToken token)
  {
    await base.InitializeAsync(token);

    if (token.IsCancellationRequested)
      return;

    this.menu.AddChoice(new Option("ToDos", async () => await this.screenManager.SetScreenAsync<TodoListScreen>(token)));

    this.menu.AddChoice(new Option("Say Hi", () =>
    {
      AnsiConsole.WriteLine("Hi Grugg!!!");
      SimpleMessage.AnyKeyToContinue();
    }));

    this.menu.AddChoice(new Option("Exit", async () =>
    {
      await this.ExitAsync(token);
    }));

    this.menu.AddChoice(new Option("Go Back", async () => await this.screenManager.Previous(token)));
  }

  public override async Task PrintAsync(CancellationToken token)
  {
    await base.PrintAsync(token);
    
    if (token.IsCancellationRequested)
      return;

    var menuPrompt = menu.ShowAsync(AnsiConsole.Console, token);

    var selection = await menuPrompt;

    selection.CallBack.Invoke();
  }
}
