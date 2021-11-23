namespace IGE.EasyConsole;
using Spectre.Console;
using System;

public static class ConsoleHelpers
{
    public static void AnyKeyToContinue()
    {
        AnsiConsole.MarkupLine("[orangered1]Press the any key to continue...[/]");
        Console.ReadKey();
    }
}
