namespace IGE.SimpleConsole;

using Ardalis.GuardClauses;

using IGE.SimpleConsole.Interfaces;
using IGE.SimpleConsole.Screen;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Spectre.Console;

public class SimpleConsoleApp : IAsyncSimpleComponent
{
  private readonly IHostApplicationLifetime applicationLifetime;
  private readonly SimpleConsoleAppOptions options;
  private readonly ScreenManager screenManager;

  public SimpleConsoleApp(
    ScreenManager screenManager,
    IHostApplicationLifetime applicationLifetime,
    SimpleConsoleAppOptions options = null!)
  {
    this.screenManager = Guard.Against.Null(screenManager, nameof(screenManager));

    this.options = options ?? SimpleConsoleAppOptions.Default;
    this.applicationLifetime = applicationLifetime;
  }



  protected ScreenManager ScreenManager => this.screenManager;

  public virtual async Task InitializeAsync(CancellationToken token = default)
  {
    await this.screenManager.InitializeAsync(token);
  }

  public virtual async Task PrintAsync(CancellationToken token = default)
  {
    await this.screenManager.PrintAsync(token);
  }

  public async Task StartAsync(CancellationToken token = default)
  {
    await this.InitializeAsync(token);

    while (!token.IsCancellationRequested)
    {
      AnsiConsole.Clear();
      await this.PrintAsync(token);
    }
  }

  public Task ExitAsync(CancellationToken token = default)
  {
    this.applicationLifetime.StopApplication();
    return Task.CompletedTask;
  }

  public static async Task RunAsync(IHost host)
  {
    var lifeTime = host.Services.GetRequiredService<IHostApplicationLifetime>();

    var src = new CancellationTokenSource();

    lifeTime.ApplicationStarted.Register(async () =>
    {
      try
      {
        var app = host.Services.GetRequiredService<SimpleConsoleApp>();
        await app.StartAsync(src.Token);
      }
      catch (Exception ex)
      {
        //TODO: Handle Exceptions;
      }
      finally
      {
        lifeTime.StopApplication();
      }
    });

    lifeTime.ApplicationStopping.Register(() =>
    {
        src.Cancel();
    });

    //await host.WaitForShutdownAsync();
  }
}
