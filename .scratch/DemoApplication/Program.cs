using DemoApplication;

using IGE.SimpleConsole;
using IGE.SimpleConsole.Setup;

using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder()
.UseSimpleConsoleApp(typeof(TitleScreen))
.Build().Run();
