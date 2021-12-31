namespace IGE.SimpleConsole.Screen;

using System;
using System.Collections.Generic;

using IGE.SimpleConsole.Interfaces;

public class ScreenManager : IPrintableComponent
{
  private readonly IServiceProvider services;

  private readonly Stack<Screen> screenStack = new Stack<Screen>();

  public ScreenManager(IServiceProvider services)
  {
    this.services = services;
  }

  public Screen CurrentScreen => this.screenStack.Peek();

  public void SetScreen<T>()
    where T : Screen
  {
    Type screenType = typeof(T);

    if (this.IsNullOrTypeOf(screenType))
      return;

    Screen nextScreen = this.services.GetService(screenType) as Screen;

    this.screenStack.Push(nextScreen);
  }

  public void Previous()
  {
    if (this.screenStack.Count > 1)
      this.screenStack.Pop();
  }

  public void NavigateHome()
  {
    while (this.screenStack.Count > 1)
      this.screenStack.Pop();
  }

  public void Print()
  {
    this.CurrentScreen.Print();
  }

  private bool IsNullOrTypeOf(Type screenType)
  {
    return this.CurrentScreen is not null
      && this.CurrentScreen.GetType() != screenType;
  }
}
