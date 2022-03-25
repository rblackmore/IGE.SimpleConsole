namespace IGE.SimpleConsole.Screen;

using System.Collections.Generic;

using IGE.SimpleConsole.Components;
using IGE.SimpleConsole.Interfaces;

using Spectre.Console;

public abstract class ScreenBase : ISimpleComponentAsync
{
  private readonly List<ISimpleComponentAsync> components = new ();
  private readonly SimpleConsoleApp app;

  public ScreenBase(SimpleConsoleApp app)
  {
    this.app = app;
  }

  public ScreenTitle ScreenTitle { get; set; } = new (string.Empty);

  protected SimpleConsoleApp App => this.app;

  protected List<ISimpleComponentAsync> Components => this.components;

  public virtual async Task InitializeAsync(CancellationToken token = default)
  {
    if (token.IsCancellationRequested)
      return;

    foreach (var component in this.Components)
    {
      await component.InitializeAsync(token);
    }
  }

  public virtual async Task PrintAsync(CancellationToken token = default)
  {
    if (token.IsCancellationRequested)
      return;

    await this.ScreenTitle.PrintAsync(token);

    foreach (var component in this.Components)
    {
      await component.PrintAsync(token);
    }
  }

  public virtual async Task ExitAsync(CancellationToken token = default)
  {
    await this.app.ExitAsync(token);
    this.components.Clear();
  }
}
