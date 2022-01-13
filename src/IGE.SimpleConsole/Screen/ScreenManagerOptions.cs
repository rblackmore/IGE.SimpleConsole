namespace IGE.SimpleConsole.Screen;

public class ScreenManagerOptions
{
  public static ScreenManagerOptions? Default => new ScreenManagerOptions();

  public Type? StartupScreenType { get; set; }

  public bool BreadCrumbTitle { get; set; } = false;
}
