namespace IGE.SimpleConsole;

public class SimpleConsoleAppOptions
{
  public static SimpleConsoleAppOptions Default => new ();

  public string[]? Args { get; init; }

  public Type? StartupScreenType { get; set; }

  public bool ShowBreadCrumb { get; set; }
}
