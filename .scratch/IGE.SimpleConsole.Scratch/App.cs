namespace IGE.SimpleConsole.Scratch;

using System.Threading;
using System.Threading.Tasks;

using IGE.SimpleConsole;
using IGE.SimpleConsole.Menu;

using Microsoft.Extensions.Hosting;

using Spectre.Console;

internal class App : ConsoleApp, IHostedService
{
  private readonly SelectionPrompt<Option> menu = new SelectionPrompt<Option>()
    .Title($"[springgreen2]Main Menu[/]");

  public App()
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
    AnsiConsole.MarkupLine("[red]Initializing[/]");
    this.menu.AddChoice(new Option("Say Hi", () => AnsiConsole.WriteLine("Hi Grugg!!!")));
    base.Initialize();
  }

  public override void Print()
  {
    AnsiConsole.MarkupLine("[green]Drawing[/]");
    base.Print();

    var selection = AnsiConsole.Prompt(menu);
    selection.CallBack.Invoke();

    AnsiConsole.WriteLine();
    SimpleMessage.AnyKeyToContinue();
  }
}
