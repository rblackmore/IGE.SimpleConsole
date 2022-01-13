namespace IGE.SimpleConsole.Scratch;

using System.Threading;
using System.Threading.Tasks;

using IGE.SimpleConsole;
using IGE.SimpleConsole.Screen;

using Microsoft.Extensions.Hosting;

using Spectre.Console;

internal class App : SimpleConsoleApp, IHostedService
{
  private readonly IHostApplicationLifetime appLifetime;

  public App(ScreenManager screenManager, IHostApplicationLifetime appLifetime)
    : base(screenManager)
  {
    this.appLifetime = appLifetime;
  }

  public Task StartAsync(CancellationToken cancellationToken)
  {
    var tokenSource = new CancellationTokenSource();

    this.appLifetime.ApplicationStarted.Register(() =>
    {
      Task.Run(async () =>
      {
        try
        {
          await this.RunAsync(tokenSource.Token);
        }
        catch (Exception ex)
        {
          // Handle Exception;
        }
        finally
        {
          this.appLifetime.StopApplication();
        }
      });
    });

    this.appLifetime.ApplicationStopping.Register(() =>
    {
      Task.Run(() =>
      {
        tokenSource.Cancel();
      });
    });

    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[red]Ending Program[/]");
    SimpleMessage.AnyKeyToContinue();
    return Task.CompletedTask;
  }

  public override async Task InitializeAsync(CancellationToken token)
  {
    await base.InitializeAsync(token);
  }

  public override async Task PrintAsync(CancellationToken token)
  {
    await base.PrintAsync(token);
  }
}
