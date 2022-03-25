using IGE.SimpleConsole;
using IGE.SimpleConsole.Scratch.Screens;

using Microsoft.Extensions.Hosting;

await CreateHostBuilder(args).Build().RunAsync();

IHostBuilder CreateHostBuilder(string[] args) =>
  Host.CreateDefaultBuilder(args)
  .UseSimpleConsoleApp(typeof(TitleScreen), options =>
  {
    options.StartupScreenType = typeof(TitleScreen);
  });
