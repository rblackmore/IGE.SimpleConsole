namespace IGE.SimpleConsole.DependencyInjection;

using System.Linq;
using System.Reflection;

using IGE.SimpleConsole.Screen;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
  /// <summary>
  /// Registers Menu Manager and Pages with Microsoft Dependency Injection.
  /// </summary>
  /// <param name="services">Services Collection.</param>
  /// <param name="screenAssembly">Assembly to search for Pages.</param>
  /// <param name="screenManagerOptionsBuilder">Screen Manager Options Builder.</param>
  /// <returns>Services Collection</returns>
  public static IServiceCollection AddSimpleMenu(
    this IServiceCollection services,
    Assembly screenAssembly,
    Action<ScreenManagerOptions> screenManagerOptionsBuilder)
  {
    var screenManagerOptions = new ScreenManagerOptions();
    screenManagerOptionsBuilder(screenManagerOptions);
    services.AddSingleton(screenManagerOptions);

    services.AddSingleton<ScreenManager>();

    var pages = screenAssembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ScreenBase)));

    foreach (var page in pages)
    {
      services.Add(new ServiceDescriptor(page, page, ServiceLifetime.Transient));
    }

    return services;
  }
}
