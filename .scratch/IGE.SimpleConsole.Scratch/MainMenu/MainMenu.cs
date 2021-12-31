namespace IGE.SimpleConsole.Scratch.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IGE.SimpleConsole.Menu;

using Spectre.Console;

public class MainMenu : MenuPage
{
  public MainMenu(MenuManager manager)
    : base("Main Menu", manager)
  {
    base.AddOption("Say Hello", () =>
    {
      AnsiConsole.WriteLine("Hello, Grugg");
      SimpleMessage.AnyKeyToContinue();
    });

    base.AddOption("About", () =>
    {
      this.Manager.NavigateTo<InformationPage>();
    });
  }
}
