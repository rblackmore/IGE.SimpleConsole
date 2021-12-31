namespace IGE.SimpleConsole.Screen;

using System.Collections.Generic;

using IGE.SimpleConsole.Interfaces;

using Spectre.Console;

public abstract class Screen : IComponent
{
  private readonly List<IComponent> components = new ();

  protected List<IComponent> Components => this.components;

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
