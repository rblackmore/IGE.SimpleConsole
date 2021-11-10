using Spectre.Console;
using System;
using System.Linq;

namespace IGE.EasyConsole.Menu
{
    public abstract class Page
    {
        public string Title { get; private set; }

        public MenuManager Manager { get; set; }

        public Page(string title, MenuManager manager)
        {
            Title = title;
            Manager = manager;
        }

        public virtual void Display()
        {
            if (Manager.History.Count > 1 && Manager.BreadcrumbHeader)
            {
                string breadcrumb = null;
                foreach (var title in Manager.History.Select((page) => page.Title).Reverse())
                    breadcrumb += title + " > ";
                breadcrumb = breadcrumb.Remove(breadcrumb.Length - 3);
                AnsiConsole.MarkupLine($"[springgreen2]{breadcrumb}[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[springgreen2]{Title}[/]");
            }

            AnsiConsole.WriteLine("===");
        }
    }
}
