namespace IGE.SimpleConsole.Scratch.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using IGE.SimpleConsole;
using IGE.SimpleConsole.Screen;

using Spectre.Console;

internal class FirstScreen : ScreenBase
{
  public FirstScreen(SimpleConsoleApp app) 
    : base("First Screen", app)
  {
  }

  public override async Task PrintAsync(CancellationToken token = default)
  {
    AnsiConsole.WriteLine("Hello, FirstScreen");
    
    SimpleMessage.AnyKeyToContinue();

    await base.PrintAsync(token);

    await this.ExitAsync(token);
  }
}
