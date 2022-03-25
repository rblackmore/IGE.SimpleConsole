namespace IGE.SimpleConsole.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using IGE.SimpleConsole.Interfaces;

using Spectre.Console;

public class ScreenTitle : ISimpleComponentAsync
{
  private string title;

  public ScreenTitle(string title)
  {
    this.title = title;
  }

  public bool Display { get; set; } = true;

  public Task InitializeAsync(CancellationToken token)
  {
    // Nothing to Initialize;
    return Task.CompletedTask;
  }

  public Task PrintAsync(CancellationToken token)
  {
    if (!this.Display)
      return Task.CompletedTask;

    AnsiConsole.Write(
      new FigletText(this.title)
      .Centered()
      .Color(Color.White));

    return Task.CompletedTask;
  }
}
