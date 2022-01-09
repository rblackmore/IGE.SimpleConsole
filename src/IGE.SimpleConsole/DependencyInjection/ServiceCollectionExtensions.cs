namespace IGE.SimpleConsole.DependencyInjection;

using System.Linq;
using System.Reflection;

using Ardalis.GuardClauses;

using IGE.SimpleConsole.Screen;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
  /// <summary>
  /// Registers Menu Manager and Pages with Microsoft Dependency Injection.
  /// </summary>
  /// <param name="services">Services Collection.</param>
  /// <param name="screenAssemblies">Assemblies to search for Screens.</param>
  /// <returns>Service Collection.</returns>
  public static IServiceCollection AddSimpleConsole(
      this IServiceCollection services,
      params Assembly[] screenAssemblies)
  {
    Guard.Against.Null(screenAssemblies, nameof(screenAssemblies));

    foreach (var assembly in screenAssemblies)
    {
      var screens = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ScreenBase)));

      foreach (var screen in screens)
      {
        services.Add(new ServiceDescriptor(screen, screen, ServiceLifetime.Transient));
      }
    }

    services.AddSingleton<ScreenManager>();

    return services;
  }

  public static IServiceCollection AddSimpleConsole(
      this IServiceCollection services,
      Action<SimpleConsoleAppOptions> simpleConsoleAppOptionsBuilder,
      params Assembly[] assemblies)
  {
    Guard.Against.Null(simpleConsoleAppOptionsBuilder, nameof(simpleConsoleAppOptionsBuilder));

    services.AddSingleton(BuildSimpleConsoleAppOptions(simpleConsoleAppOptionsBuilder));

    services.AddSimpleConsole(assemblies);

    return services;
  }

  public static IServiceCollection AddSimpleConsole(
      this IServiceCollection services,
      Action<ScreenManagerOptions> screenManagerOptionsBuilder,
      params Assembly[] assemblies)
  {
    Guard.Against.Null(screenManagerOptionsBuilder, nameof(screenManagerOptionsBuilder));

    services.AddSingleton(BuildScreenManagerOptions(screenManagerOptionsBuilder));

    services.AddSimpleConsole(assemblies);

    return services;
  }

  public static IServiceCollection AddSimpleConsole(
      this IServiceCollection services,
      Action<SimpleConsoleAppOptions> simpleConsoleAppOptionsBuilder,
      Action<ScreenManagerOptions> screenManagerOptionsBuilder,
      params Assembly[] assemblies)
  {
    Guard.Against.Null(simpleConsoleAppOptionsBuilder, nameof(simpleConsoleAppOptionsBuilder));
    Guard.Against.Null(screenManagerOptionsBuilder, nameof(screenManagerOptionsBuilder));

    services.AddSingleton(BuildSimpleConsoleAppOptions(simpleConsoleAppOptionsBuilder));
    services.AddSingleton(BuildScreenManagerOptions(screenManagerOptionsBuilder));

    services.AddSimpleConsole(assemblies);

    return services;
  }

  private static SimpleConsoleAppOptions BuildSimpleConsoleAppOptions(Action<SimpleConsoleAppOptions> builder)
  {
    var options = new SimpleConsoleAppOptions();
    builder(options);
    return options;
  }

  private static ScreenManagerOptions BuildScreenManagerOptions(Action<ScreenManagerOptions> builder)
  {
    var options = new ScreenManagerOptions();
    builder(options);
    return options;
  }
}
