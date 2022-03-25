using IGE.SimpleConsole;
using IGE.SimpleConsole.Scratch.Screens;
using IGE.SimpleConsole.Setup;

using Microsoft.Extensions.Hosting;

await CreateHostBuilder(args).Build().RunAsync();

//await SimpleConsoleApp.RunAsync(CreateHost(args));

IHostBuilder CreateHostBuilder(string[] args) =>
  Host.CreateDefaultBuilder(args)
  .UseSimpleConsoleApp(typeof(TitleScreen), options =>
  {
    options.SetStartScreen(typeof(TitleScreen));
  });
