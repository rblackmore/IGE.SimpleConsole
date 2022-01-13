namespace IGE.SimpleConsole.Interfaces;

public interface IAsyncSimpleComponent
{
  Task InitializeAsync(CancellationToken token);

  Task PrintAsync(CancellationToken token);
}
