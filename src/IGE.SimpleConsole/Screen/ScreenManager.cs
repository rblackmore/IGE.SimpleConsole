namespace IGE.SimpleConsole.Screen;

using System;
using System.Collections.Generic;

using Ardalis.GuardClauses;

using IGE.SimpleConsole.Exceptions;

public class ScreenManager
{
  private readonly IServiceProvider? services;

  private readonly ScreenManagerOptions options;

  private readonly Stack<ScreenBase> screenStack = new ();

  public ScreenManager(ScreenManagerOptions options)
  {
    this.options = Guard.Against.Null(options, nameof(options));
  }

  public ScreenManager(IServiceProvider services, ScreenManagerOptions options)
    : this(options)
  {
    this.services = services;
  }

  private ScreenBase CurrentScreen =>
    (this.screenStack.Count > 0) ? this.screenStack.Peek() : null!;

  public async Task InitializeAsync(CancellationToken token)
  {
    if (this.options.StartupScreenType is not null)
      await this.SetScreenAsync(this.options.StartupScreenType, token);
  }

  public Task ExitAsync(CancellationToken token)
  {
    this.screenStack.Clear();

    return Task.CompletedTask;
  }

  public async Task SetScreenAsync(Type screenType, CancellationToken token)
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

    await this.CurrentScreen.InitializeAsync(token);
  }

  public async Task SetScreenAsync<T>(CancellationToken token)
    where T : ScreenBase
  {
    Type screenType = typeof(T);

    await this.SetScreenAsync(screenType, token);
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

  public async Task PrintAsync(CancellationToken token)
  {
    await this.CurrentScreen.PrintAsync(token);
  }

  private bool IsNullOrTypeOf(Type screenType)
  {
    return this.CurrentScreen is not null
      && this.CurrentScreen.GetType() == screenType;
  }

  private void SetWindowTitle()
  {
    // TODO: Check screen options if breadcrumb title. Then set title accordingly.
  }
}
