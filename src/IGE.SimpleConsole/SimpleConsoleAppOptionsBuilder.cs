namespace IGE.SimpleConsole;
using System;

using Ardalis.GuardClauses;

using IGE.SimpleConsole.Exceptions;
using IGE.SimpleConsole.Screen;

public static class SimpleConsoleAppOptionsBuilder
{
  public static SimpleConsoleAppOptions SetStartScreen(this SimpleConsoleAppOptions options, Type startScreenType)
  {
    Guard.Against.Null(startScreenType, nameof(startScreenType));

    if (!startScreenType.IsSubclassOf(typeof(ScreenBase)))
      throw new InvalidScreenTypeException(startScreenType, startScreenType.Name);

    options.StartupScreenType = startScreenType;

    return options;
  }
}
