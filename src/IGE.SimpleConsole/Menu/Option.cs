﻿namespace IGE.EasyConsole.Menu;
using System;

public class Option
{
    public string Name { get; private set; }
    public Action CallBack { get; set; }

    public Option(string name, Action callBack)
    {
        Name = name;
        CallBack = callBack;
    }

    public override string ToString()
    {
        return this.Name;
    }
}