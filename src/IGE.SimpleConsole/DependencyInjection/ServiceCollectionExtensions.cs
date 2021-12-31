namespace IGE.SimpleConsole.DependencyInjection;

using System;
using System.Linq;
using System.Reflection;

using IGE.SimpleConsole.Menu;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
  /// <summary>
  /// Registers Menu Manager and Pages with Microsoft Dependency Injection.
  /// </summary>
  /// <param name="services">Services Collection.</param>
  /// <param name="menuAssembly">Assembly to search for Pages.</param>
  /// <returns>Services Collection</returns>
  public static IServiceCollection AddSimpleMenu(
    this IServiceCollection services,
    Assembly menuAssembly,
    Action<MenuManagerOptions> optionsBuilder)
  {

    var options = new MenuManagerOptions();
    optionsBuilder(options);
    services.AddSingleton(options);

    services.AddSingleton<MenuManager>();

    var pages = menuAssembly.GetTypes().Where(t => t.IsAssignableTo(typeof(Page)));

    foreach (var page in pages)
    {
      services.Add(new ServiceDescriptor(page, page, ServiceLifetime.Transient));
    }

    return services;
  }
}
