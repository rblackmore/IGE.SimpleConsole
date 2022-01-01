namespace IGE.SimpleConsole.Screen;

using System;
using System.Collections.Generic;

public class ScreenManager
{
  private readonly IServiceProvider services;

  private readonly Stack<ScreenBase> screenStack = new Stack<ScreenBase>();

  public ScreenManager()
  {
  }

  public ScreenManager(IServiceProvider services)
  {
    this.services = services;
  }

  public ScreenBase CurrentScreen =>
    this.screenStack.Count > 0 ? this.screenStack.Peek() : null;

  public void SetScreen<T>()
    where T : ScreenBase
  {
    Type screenType = typeof(T);

    if (this.IsNullOrTypeOf(screenType))
      return;

    ScreenBase nextScreen;

    if (this.services is null)
      nextScreen = Activator.CreateInstance(screenType) as ScreenBase;
    else
      nextScreen = this.services.GetService(screenType) as ScreenBase;

    this.screenStack.Push(nextScreen);

    this.CurrentScreen.Initialize();
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
      && this.CurrentScreen.GetType() == screenType;
  }
}
