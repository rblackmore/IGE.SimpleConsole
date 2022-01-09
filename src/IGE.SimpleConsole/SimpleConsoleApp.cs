namespace IGE.SimpleConsole;

using Ardalis.GuardClauses;

using IGE.SimpleConsole.Interfaces;
using IGE.SimpleConsole.Screen;

using Spectre.Console;

public abstract class SimpleConsoleApp : ISimpleComponent
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

  public virtual void Initialize()
  {
  }

  public virtual void Print()
  {
    this.screenManager.Print();
  }

  public void Run()
  {
    this.Initialize();

    while (!this.isExited)
    {
      AnsiConsole.Clear();
      this.Print();
    }
  }

  public void Exit()
  {
    this.isExited = true;
  }
}
