namespace IGE.SimpleConsole.Screen;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using IGE.SimpleConsole.Interfaces;

using Spectre.Console;

public abstract class ScreenBase : IAsyncSimpleComponent
{
  private readonly List<IAsyncSimpleComponent> components = new();

  public ScreenBase(string title)
  {
    this.ScreenTitle = Guard.Against.NullOrEmpty(title, nameof(title));
  }

  public string ScreenTitle { get; }

  protected List<IAsyncSimpleComponent> Components => this.components;

  public virtual async Task InitializeAsync(CancellationToken token)
  {
    if (token.IsCancellationRequested)
      return;

    foreach (var component in this.Components)
    {
      await component.InitializeAsync(token);
    }
  }

  public virtual async Task PrintAsync(CancellationToken token)
  {
    if (token.IsCancellationRequested)
      return;

    foreach (var component in this.Components)
    {
      await component.PrintAsync(token);
    }
  }

  public virtual void Exit()
  {
    this.components.Clear();
  }
}
