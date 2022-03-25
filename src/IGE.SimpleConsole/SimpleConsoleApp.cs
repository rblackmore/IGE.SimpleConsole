namespace IGE.SimpleConsole;

using Ardalis.GuardClauses;

using IGE.SimpleConsole.Interfaces;
using IGE.SimpleConsole.Screen;

using Microsoft.Extensions.Hosting;

using Spectre.Console;

public class SimpleConsoleApp : IAsyncSimpleComponent, IHostedService
{
  private readonly SimpleConsoleAppOptions options;
  private readonly ScreenManager screenManager;
  private bool isExited = false;

  public SimpleConsoleApp(
    ScreenManager screenManager,
    SimpleConsoleAppOptions options = null!)
  {
    this.screenManager = Guard.Against.Null(screenManager, nameof(screenManager));

    this.options = options ?? SimpleConsoleAppOptions.Default;
  }

  protected ScreenManager ScreenManager => this.screenManager;

  public virtual async Task InitializeAsync(CancellationToken token = default)
  {
    await this.screenManager.InitializeAsync(token);
  }

  public virtual async Task PrintAsync(CancellationToken token = default)
  {
    await this.screenManager.PrintAsync(token);
  }

  public async Task RunAsync(CancellationToken token = default)
  {
    await this.InitializeAsync(token);

    while (!token.IsCancellationRequested)
    {
      AnsiConsole.Clear();
      await this.PrintAsync(token);
    }
  }

  public async Task ExitAsync(CancellationToken token)
  {
    this.isExited = true;
    await this.screenManager.ExitAsync(token);
  }

  public async Task StartAsync(CancellationToken cancellationToken)
  {
    await this.RunAsync(cancellationToken);
  }

  public async Task StopAsync(CancellationToken cancellationToken)
  {
    await this.ExitAsync(cancellationToken);
  }
}
