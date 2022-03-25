namespace IGE.SimpleConsole.Screen;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using IGE.SimpleConsole.Interfaces;

using Spectre.Console;

public abstract class ScreenBase : IAsyncSimpleComponent
{
  private readonly List<IAsyncSimpleComponent> components = new ();
  private readonly SimpleConsoleApp app;

  public ScreenBase(string title, SimpleConsoleApp app)
  {
    this.ScreenTitle = Guard.Against.NullOrEmpty(title, nameof(title));
    this.app = app;
  }

  public string ScreenTitle { get; }

  protected SimpleConsoleApp App => this.app;

  protected List<IAsyncSimpleComponent> Components => this.components;

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
