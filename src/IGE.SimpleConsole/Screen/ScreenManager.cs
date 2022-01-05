namespace IGE.SimpleConsole.Screen;

using System;
using System.Collections.Generic;

using IGE.SimpleConsole.Exceptions;

public class ScreenManager
{
  private readonly IServiceProvider? services;

  private readonly ScreenManagerOptions options;

  private readonly Stack<ScreenBase> screenStack = new();

  public ScreenManager(ScreenManagerOptions options)
  {
    if (options is null)
      throw new ArgumentNullException(nameof(options));

    this.options = options;

    if (options.StartupScreenType is not null)
      this.SetScreen(options.StartupScreenType);
  }

  public ScreenManager(IServiceProvider services, ScreenManagerOptions options)
  {
    if (options is null)
      throw new ArgumentNullException(nameof(options));

    this.services = services;
    this.options = options;

    if (options.StartupScreenType is not null)
      this.SetScreen(options.StartupScreenType);
  }

  public ScreenBase CurrentScreen =>
    this.screenStack.Count > 0 ? this.screenStack.Peek() : null!;

  public void SetScreen(Type screenType)
  {
    if (this.IsNullOrTypeOf(screenType))
      return;

    ScreenBase? nextScreen;

    if (this.services is null)
      nextScreen = Activator.CreateInstance(screenType) as ScreenBase;
    else
      nextScreen = this.services.GetService(screenType) as ScreenBase;

    if (nextScreen == null)
      throw new InvalidScreenTypeException(screenType, screenType.Name);

    this.screenStack.Push(nextScreen);

    this.CurrentScreen.Initialize();
  }

  public void SetScreen<T>()
    where T : ScreenBase
  {
    Type screenType = typeof(T);

    this.SetScreen(screenType);
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
