namespace IGE.SimpleConsole;

using System;
using System.Reflection;

using IGE.SimpleConsole.Screen;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class SimpleConsoleAppBuilder
{
  public static IHostBuilder UseSimpleConsoleApp(this IHostBuilder hostBuilder, Type assemblyMarker, Action<SimpleConsoleAppOptions> options)
  {
    var screenAssembly = assemblyMarker.Assembly;

    return hostBuilder.UseSimpleConsoleApp(screenAssembly, options);
  }

  public static IHostBuilder UseSimpleConsoleApp(this IHostBuilder hostBuilder, Assembly assembly, Action<SimpleConsoleAppOptions> options)
  {
    var opt = new SimpleConsoleAppOptions();

    options.Invoke(opt);
    hostBuilder.ConfigureServices((hostContext, services) =>
    {
      services.AddHostedService<SimpleConsoleApp>();
      services.AddSingleton<ScreenManager>();
      services.AddSingleton(opt);
      services.AddScreensFromAssembly(assembly);
    });

    return hostBuilder;
  }

  private static IServiceCollection AddScreensFromAssembly(
    this IServiceCollection services,
    Assembly screenAssembly)
  {
    var screens =
      screenAssembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ScreenBase)));

    foreach (var screen in screens)
    {
      services
        .Add(new ServiceDescriptor(screen, screen, ServiceLifetime.Transient));
    }

    return services;
  }
}
