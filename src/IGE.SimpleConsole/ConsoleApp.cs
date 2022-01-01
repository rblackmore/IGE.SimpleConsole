namespace IGE.SimpleConsole;

using IGE.SimpleConsole.Interfaces;
using IGE.SimpleConsole.Screen;

using Spectre.Console;

public abstract class ConsoleApp : ISimpleComponent
{
  private readonly ScreenManager screenManager;

  private bool isExited = false;

  public ConsoleApp(ScreenManager screenManager)
  {
    this.screenManager = screenManager;
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
