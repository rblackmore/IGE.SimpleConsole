namespace IGE.SimpleConsole;

public class SimpleConsoleAppOptions
{
  public string? Title { get; set; }

  public static SimpleConsoleAppOptions Default => new () { Title = null };
}
