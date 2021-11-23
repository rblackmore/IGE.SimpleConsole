namespace IGE.SimpleConsole.Scratch;

using System.Threading;
using System.Threading.Tasks;

using IGE.SimpleConsole;

using Microsoft.Extensions.Hosting;

using Spectre.Console;

internal class App : IHostedService
{
  public Task StartAsync(CancellationToken cancellationToken)
  {
    AnsiConsole.MarkupLine("[green]Beginning Program[/]");
    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    AnsiConsole.MarkupLine("[red]Ending Program[/]");
    SimpleMessage.AnyKeyToContinue();
    return Task.CompletedTask;
  }
}
