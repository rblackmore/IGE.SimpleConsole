using IGE.SimpleConsole;
using IGE.SimpleConsole.Screen;

var app = new App(SingleTons.ScreenManager);

app.Run();


public static class SingleTons
{
  private static ScreenManager? screenManager;

  public static ScreenManager ScreenManager =>
    screenManager ??= new ScreenManager();
}

public class App : SimpleConsoleApp
{
  public App(ScreenManager screenManager)
    : base(screenManager)
  {
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

public class TitleScreen : ScreenBase
{
  public override void Initialize()
  {
    base.Initialize();
  }

  public override void Print()
  {
    Console.WriteLine("Hello from TitleScreen");
    SimpleMessage.AnyKeyToContinue();
    SingleTons.ScreenManager.SetScreen<SecondScreen>();

    base.Print();
  }
}

public class SecondScreen : ScreenBase
{
  public override void Print()
  {
    Console.WriteLine("Hello From Second Screen");
    base.Print();
  }
}
