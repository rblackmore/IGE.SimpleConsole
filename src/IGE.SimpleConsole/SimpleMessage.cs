namespace IGE.SimpleConsole;
using System;

using Spectre.Console;

public static class SimpleMessage
{
  public static void AnyKeyToContinue()
  {
    AnsiConsole.MarkupLine("[orangered1]Press the any key to continue...[/]");
    Console.ReadKey();
  }
}
