namespace IGE.SimpleConsole.Scratch.Screens;

using IGE.SimpleConsole.Screen;

using Microsoft.Extensions.Hosting;

using Spectre.Console;

public class MainMenuScreen : ScreenBase
{
  private readonly SelectionPrompt<Option> menu = new SelectionPrompt<Option>()
    .Title($"[springgreen2]Main Menu[/]");

  private readonly ScreenManager screenManager;
  private readonly IHostApplicationLifetime applicationLifetime;

  public MainMenuScreen(ScreenManager screenManager, IHostApplicationLifetime applicationLifetime)
    : base("Main Menu")
  {
    this.screenManager = screenManager;
    this.applicationLifetime = applicationLifetime;
  }

  public override async Task InitializeAsync(CancellationToken token)
  {
    await base.InitializeAsync(token);

    if (token.IsCancellationRequested)
      return;

    this.menu.AddChoice(new Option("Say Hi", () =>
    {
      AnsiConsole.WriteLine("Hi Grugg!!!");
      SimpleMessage.AnyKeyToContinue();
    }));

    this.menu.AddChoice(new Option("Exit", () =>
    {
      this.applicationLifetime.StopApplication();
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
