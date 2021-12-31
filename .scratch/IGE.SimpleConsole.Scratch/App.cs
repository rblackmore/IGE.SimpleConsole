namespace IGE.SimpleConsole.Scratch;

using System.Threading;
using System.Threading.Tasks;

using IGE.SimpleConsole;
using IGE.SimpleConsole.Menu;

using Microsoft.Extensions.Hosting;

using Spectre.Console;

internal class App : IHostedService
{
  private readonly MenuManager menuManager;

  public App(MenuManager menuManager)
  {
    this.menuManager = menuManager;
    this.menuManager.SetPage<MainMenu.MainMenu>();
  }

  public Task StartAsync(CancellationToken cancellationToken)
  {
    this.menuManager.Run();
    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    AnsiConsole.MarkupLine("[red]Ending Program[/]");
    SimpleMessage.AnyKeyToContinue();
    return Task.CompletedTask;
  }
}
