namespace IGE.SimpleConsole.Scratch.Screens;
using System.Threading;
using System.Threading.Tasks;

using IGE.SimpleConsole;
using IGE.SimpleConsole.Screen;

using Spectre.Console;

internal class TodoListScreen : ScreenBase
{
  private readonly IDataService<Todo> repo;

  private SelectionPrompt<Option> menu = new SelectionPrompt<Option>();

  public TodoListScreen(SimpleConsoleApp app, IDataService<Todo> todoRepo) 
    : base(app)
  {
    repo = todoRepo;
  }

  public override async Task InitializeAsync(CancellationToken token = default)
  {
    menu.AddChoice(new Option("Show All", GetAll));
    menu.AddChoice(new Option("Get By Id", GetById));
    menu.AddChoice(new Option("Update", Update));
    menu.AddChoice(new Option("Create", CreateNew));
    menu.AddChoice(new Option("Delete", Delete));

    await base.InitializeAsync(token);
  }

  public override async Task PrintAsync(CancellationToken token = default)
  {
    var selection = await this.menu.ShowAsync(AnsiConsole.Console, token);

    selection.CallBack.Invoke();
  }

  private void GetById()
  {
    
  }

  private void GetAll()
  {
    Table todoTable = new Table();
    todoTable.Title("Todo Items");

    todoTable.AddColumns("ID", "Name", "Complete");

    foreach (var todo in this.repo.GetAll())
    {
      todoTable.AddRow(todo.Id.ToString(), todo.Name, todo.IsComplete.ToString());
    }

    AnsiConsole.Write(todoTable);

    SimpleMessage.AnyKeyToContinue();
  }

  private void CreateNew()
  {
    var name = AnsiConsole.Ask<string>("Todo Name: ");
    var isComplete = AnsiConsole.Ask<bool>("Is Complete (True or False): ");

    var todo = new Todo(0, name, isComplete);

    this.repo.Create(todo);
  }

  private void Update()
  {

  }

  private void Delete()
  {

  }
}
