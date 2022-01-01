namespace IGE.SimpleConsole.Screen;

using System.Collections.Generic;

using IGE.SimpleConsole.Interfaces;

using Spectre.Console;

public abstract class ScreenBase : ISimpleComponent
{
  private readonly List<ISimpleComponent> components = new();

  protected List<ISimpleComponent> Components => this.components;

  public virtual void Initialize()
  {
    foreach (var component in this.components)
    {
      component.Initialize();
    }
  }

  public virtual void Print()
  {
    foreach (var component in this.components)
    {
      component.Print();
    }
  }
}
