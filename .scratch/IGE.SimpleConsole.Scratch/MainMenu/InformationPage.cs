namespace IGE.SimpleConsole.Scratch.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IGE.SimpleConsole.Menu;

using Spectre.Console;

public class InformationPage : Page
{
  public InformationPage(MenuManager manager) :
    base("About", manager)
  {

  }

  public override void Display()
  {
    base.Display();

    AnsiConsole.WriteLine("Some Cool Info about my App!!!");
    SimpleMessage.AnyKeyToContinue();
  }
}
