using Spectre.Console;
using System;

namespace IGE.EasyConsole
{
    public static class ConsoleHelpers
    {
        public static void AnyKeyToContinue()
        {
            AnsiConsole.MarkupLine("[orangered1]Press the any key to continue...[/]");
            Console.ReadKey();
        }
    }
}
