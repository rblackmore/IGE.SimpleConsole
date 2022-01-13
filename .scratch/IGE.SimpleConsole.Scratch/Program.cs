namespace IGE.SimpleConsole.Scratch;

using System.Reflection;

using IGE.SimpleConsole.DependencyInjection;
using IGE.SimpleConsole.Scratch.Screens;
using IGE.SimpleConsole.Screen;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class Program
{
  public static async Task Main(string[] args)
  {
    await CreateHostBuilder(args).Build().RunAsync();
  }

  private static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
      services.AddSimpleConsole(
        (ScreenManagerOptions options) => options.StartupScreenType = typeof(TitleScreen),
        Assembly.GetExecutingAssembly());

      services.AddHostedService<App>();
    });
}
