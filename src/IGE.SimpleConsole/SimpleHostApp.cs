namespace IGE.SimpleConsole;

using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

internal class SimpleHostApp : IHostedService
{

  private readonly IHost host;

  public SimpleHostApp(IHost host)
  {
    this.host = host;
  }

  public async Task StartAsync(CancellationToken cancellationToken)
  {
    await SimpleConsoleApp.RunAsync(this.host);
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
   return Task.CompletedTask;
  }
}
