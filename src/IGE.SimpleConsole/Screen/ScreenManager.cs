namespace IGE.SimpleConsole.Screen;

using System;
using System.Collections.Generic;

using Ardalis.GuardClauses;

using IGE.SimpleConsole.Exceptions;

public class ScreenManager
{
  private readonly IServiceProvider? services;

  private readonly ScreenManagerOptions options;

  private readonly Stack<Type> screenHistory = new ();

  private ScreenBase? currentScreen;

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
    this.currentScreen!;

  private Type Current =>
    this.screenHistory.Count > 0 ? this.screenHistory.Peek() : null!;

  public async Task InitializeAsync(CancellationToken token)
  {
    if (this.options.StartupScreenType is not null)
      await this.SetScreenAsync(this.options.StartupScreenType, token);
  }

  public Task ExitAsync(CancellationToken token)
  {
    this.screenHistory.Clear();

    return Task.CompletedTask;
  }

  public async Task SetScreenAsync(Type screenType, CancellationToken token)
  {
    if (this.IsNullOrTypeOf(screenType))
      return;

    ScreenBase? newScreenInstance;

    if (this.services is null)
      newScreenInstance = Activator.CreateInstance(screenType) as ScreenBase;
    else
      newScreenInstance = this.services.GetService(screenType) as ScreenBase;

    if (newScreenInstance == null)
      throw new InvalidScreenTypeException(screenType, screenType.Name);

    this.screenHistory.Push(screenType);

    this.currentScreen = newScreenInstance;

    await this.CurrentScreen.InitializeAsync(token);
  }

  public async Task SetScreenAsync<T>(CancellationToken token)
    where T : ScreenBase
  {
    Type screenType = typeof(T);

    await this.SetScreenAsync(screenType, token);
  }

  public async Task Previous(CancellationToken token)
  {
    if (this.screenHistory.Count > 1)
      this.screenHistory.Pop();

    await this.SetScreenAsync(this.screenHistory.Peek(), token);
  }

  public Task NavigateHome(CancellationToken token)
  {
    while (this.screenHistory.Count > 1)
      this.screenHistory.Pop();

    return Task.CompletedTask;
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
