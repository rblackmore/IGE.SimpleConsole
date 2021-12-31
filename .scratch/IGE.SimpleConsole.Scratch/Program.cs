namespace IGE.SimpleConsole.Scratch;

using System.Reflection;

using IGE.SimpleConsole.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class Program
{
  public static void Main(string[] args)
  {
    CreateHostBuilder(args).Build().Run();
  }

  private static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
      services.AddHostedService<App>();

    });
}
