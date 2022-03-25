namespace IGE.SimpleConsole.Interfaces;

public interface ISimpleComponentAsync
{
  Task InitializeAsync(CancellationToken token);

  Task PrintAsync(CancellationToken token);
}
