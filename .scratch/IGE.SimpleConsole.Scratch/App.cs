namespace IGE.SimpleConsole.Scratch;

using System.Threading;
using System.Threading.Tasks;

using IGE.SimpleConsole;
using IGE.SimpleConsole.Scratch.Screens;
using IGE.SimpleConsole.Screen;

using Microsoft.Extensions.Hosting;

using Spectre.Console;

internal class App : ConsoleApp, IHostedService
{
  public App(ScreenManager screenManager)
    : base(screenManager)
  {
  }

  public Task StartAsync(CancellationToken cancellationToken)
  {
    this.Run();

    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    AnsiConsole.MarkupLine("[red]Ending Program[/]");
    SimpleMessage.AnyKeyToContinue();
    return Task.CompletedTask;
  }

  public override void Initialize()
  {
    this.ScreenManager.SetScreen<TitleScreen>();

    base.Initialize();
  }

  public override void Print()
  {
    base.Print();
  }
}
