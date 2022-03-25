namespace IGE.SimpleConsole;

public class SimpleConsoleAppOptions
{
  public static SimpleConsoleAppOptions Default { get; internal set; }
  public string[]? Args { get; init; }

  public string? EnvironmentName { get; init; }

  public string? ApplicationName { get; init; }

  public string? ContentRootPath { get; init; }

  public Type? StartupScreenType { get; set; }

  public bool ShowBreadCrumb { get; set; }
}
