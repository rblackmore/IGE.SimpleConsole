namespace IGE.SimpleConsole.Menu;
using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Hosting;

using Spectre.Console;

public class MenuManager
{
  private readonly IServiceProvider serviceProvider;
  private readonly IHostApplicationLifetime hostLifetime;

  protected string WindowTitle { get; set; }

  public bool BreadcrumbHeader { get; private set; }

  protected Page CurrentPage
  {
    get
    {
      return (History.Any()) ? History.Peek() : null;
    }
  }

  private Dictionary<Type, Page> Pages { get; set; }

  public Stack<Page> History { get; private set; }

  public bool NavigationEnabled { get { return History.Count > 1; } }

  public MenuManager(
    IServiceProvider serviceProvider,
    IHostApplicationLifetime hostLifetime,
    MenuManagerOptions options = null)
  {
    Pages = new Dictionary<Type, Page>();
    History = new Stack<Page>();

    if (options != null)
    {
      WindowTitle = options.WindowTitle;
      BreadcrumbHeader = options.BreadCrumbHeader;
    }

    this.serviceProvider = serviceProvider;
    this.hostLifetime = hostLifetime;
  }

  public virtual void Run()
  {
    try
    {
      Console.Title = WindowTitle;

      do
      {
        AnsiConsole.Clear();
        CurrentPage.Display();

      } while (this.History.Count > 0);
    }
    catch (Exception e)
    {
      AnsiConsole.WriteException(e);
    }
  }

  public void AddPage(Page page)
  {
    Type pageType = page.GetType();

    if (Pages.ContainsKey(pageType))
      Pages[pageType] = page;
    else
      Pages.Add(pageType, page);
  }

  public void NavigateHome()
  {
    while (History.Count > 1)
      History.Pop();

    AnsiConsole.Clear();
    CurrentPage.Display();
  }

  public T SetPage<T>() where T : Page
  {
    Type pageType = typeof(T);

    if (CurrentPageIsNullOrSameTypeAs(pageType))
      return CurrentPage as T;

    Page nextPage = this.serviceProvider.GetService(pageType) as Page;

    History.Push(nextPage);

    return CurrentPage as T;
  }


  public T NavigateTo<T>() where T : Page
  {
    SetPage<T>();

    AnsiConsole.Clear();
    CurrentPage.Display();
    return CurrentPage as T;
  }

  public Page NavigateBack()
  {
    History.Pop();

    AnsiConsole.Clear();
    CurrentPage.Display();
    return CurrentPage;
  }

  public void Exit()
  {
    this.History.Clear();
    this.hostLifetime.StopApplication();
  }

  private bool CurrentPageIsNullOrSameTypeAs(Type pageType)
  {
    return CurrentPage != null && CurrentPage.GetType() == pageType;
  }

  public int HistoryCount()
  {
    return this.History.Count;
  }
}
