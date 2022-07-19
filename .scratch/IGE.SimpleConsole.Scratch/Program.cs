using IGE.SimpleConsole;
using IGE.SimpleConsole.Scratch;
using IGE.SimpleConsole.Scratch.Screens;
using IGE.SimpleConsole.Setup;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await CreateHostBuilder(args).Build().RunAsync();

IHostBuilder CreateHostBuilder(string[] args) =>
  Host.CreateDefaultBuilder(args)
  .ConfigureServices(services =>
  {
    services.AddTransient<IDataService<Todo>, DataServiceRepo>();
  })
  .UseSimpleConsoleApp(typeof(TitleScreen), options =>
  {
    options.SetStartScreen(typeof(TitleScreen));
  });
