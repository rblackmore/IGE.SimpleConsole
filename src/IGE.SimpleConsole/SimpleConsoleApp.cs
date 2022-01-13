namespace IGE.SimpleConsole;

using Ardalis.GuardClauses;

using IGE.SimpleConsole.Interfaces;
using IGE.SimpleConsole.Screen;

using Spectre.Console;

public abstract class SimpleConsoleApp : IAsyncSimpleComponent
{
  private readonly SimpleConsoleAppOptions options;
  private readonly ScreenManager screenManager;

  private bool isExited = false;

  public SimpleConsoleApp(ScreenManager screenManager, SimpleConsoleAppOptions options = null!)
  {
    this.screenManager = Guard.Against.Null(screenManager, nameof(screenManager));

    this.options = options ?? SimpleConsoleAppOptions.Default;
  }

  protected ScreenManager ScreenManager => this.screenManager;

  public virtual async Task InitializeAsync(CancellationToken token)
  {
    await this.screenManager.InitializeAsync(token);
  }

  public virtual async Task PrintAsync(CancellationToken token)
  {
    await this.screenManager.PrintAsync(token);
  }

  public async Task RunAsync(CancellationToken token)
  {
    await this.InitializeAsync(token);

    while (!this.isExited)
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
}
