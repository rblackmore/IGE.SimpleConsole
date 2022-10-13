namespace IGE.SimpleConsole.Screen;

using System.Threading;
using System.Threading.Tasks;

using IGE.SimpleConsole.Components;

internal class DefaultTitleScreen : ScreenBase
{
  public DefaultTitleScreen(SimpleConsoleApp app)
    : base(app)
  {
    this.ScreenTitle = new ScreenTitle("Welcome to SimpleConsole");
  }

  public override async Task PrintAsync(CancellationToken token = default)
  {
    await base.PrintAsync(token);

    SimpleMessage.AnyKeyToContinue();
  }
}
