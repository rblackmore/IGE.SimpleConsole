using IGE.SimpleConsole;
using IGE.SimpleConsole.Scratch.Screens;
using IGE.SimpleConsole.Setup;

using Microsoft.Extensions.Hosting;

await SimpleConsoleApp.RunAsync(CreateHost(args));

IHost CreateHost(string[] args) =>
  Host.CreateDefaultBuilder(args)
  .UseSimpleConsoleApp(typeof(TitleScreen), options =>
  {
    options.StartupScreenType = typeof(TitleScreen);
  })
  .Build();
