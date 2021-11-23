namespace IGE.EasyConsole.Menu;
using Spectre.Console;
using System;
using System.Collections.Generic;

public abstract class MenuPage : Page
{
    private Stack<Option> options;

    public MenuPage(string title, MenuManager manager)
        : base(title, manager)
    {
        options = new Stack<Option>();
    }

    public MenuPage Add(string name, Action callback)
    {
        return Add(new Option(name, callback));
    }

    public MenuPage Add(Option option)
    {
        this.options.Push(option);
        return this;
    }

    public MenuPage Add(Option[] options)
    {
        foreach (var opt in options)
            this.options.Push(opt);

        return this;
    }

    public override void Display()
    {
        base.Display();

        AnsiConsole.WriteLine();

        var selectionPrompt = new SelectionPrompt<Option>()
            .Title($"[springgreen2]{Title}[/]")
            .AddChoices(options);

        if (Manager.NavigationEnabled)
            selectionPrompt.AddChoice(new Option("Back", () => Manager.NavigateBack()));

        selectionPrompt.AddChoice(new Option("Exit", Manager.Exit));

        var selection = AnsiConsole.Prompt(selectionPrompt);

        selection.CallBack.Invoke();
    }
}
