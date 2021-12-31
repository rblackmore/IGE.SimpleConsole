namespace IGE.SimpleConsole;

using IGE.SimpleConsole.Interfaces;

using Spectre.Console;

public abstract class ConsoleApp : IPrintableComponent
{
  private bool isExited = false;

  public virtual void Initialize()
  {

  }

  public virtual void Print()
  {

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
