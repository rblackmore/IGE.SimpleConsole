# IGE.SimpleConsole

---

IGE.SimpleConsole allows the creation of a .NET 6.0 Console application with multiple screens to manage menus, and functionality in simple defined classes calls 'Screens'.

These screens can be as simple or as complex as you need them to be.

### Features

- Hosting
- Dependecy Injection
- Screen Management
- Component System
- Menus (Planned\*)

### Quick Start

---

First create a Screen class that inherits from the abstract class `ScreenBase`.
`ScreenBase` Requires the SimpleConsoleApp to be injected to it's contructor, so you must implement a constructor which takes in this object.

```csharp
public class TitleScreen : ScreenBase
{
  public TitleScreen(SimpleConsoleApp app)
    : base(app)
  {
  }
}
```

Using `Microsoft.Extensions.Hosting`, create a Generic `IHostBuilder`, call the extension method `UseSimpleConsoleApp()`, **Build** it and **Run** it.

```csharp
using IGE.SimpleConsole;
using IGE.SimpleConsole.Setup;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder()
  .UseSimpleConsoleApp(typeof(TitleScreen));
  .Build().Run();
```
If you run this, you should see the following. Pressing any key will simply redraw the same thing over again.
```
                                         ____    _                       _             ____                                 _
                                        / ___|  (_)  _ __ ___    _ __   | |   ___     / ___|   ___    _ __    ___    ___   | |   ___
                                        \___ \  | | | '_ ` _ \  | '_ \  | |  / _ \   | |      / _ \  | '_ \  / __|  / _ \  | |  / _ \
                                         ___) | | | | | | | | | | |_) | | | |  __/   | |___  | (_) | | | | | \__ \ | (_) | | | |  __/
                                        |____/  |_| |_| |_| |_| | .__/  |_|  \___|    \____|  \___/  |_| |_| |___/  \___/  |_|  \___|
                                                                |_|
Press the any key to continue...
```
#### UseSimpleConsoleApp() Extension Methods

#### Dependency Injection

#### Screen Management

#### Component System

#### Simple Messages

### Dependencies

- Ardalis.GuardClauses v4.0.0
- Microsoft.Extensions.DependencyInjection v6.0.0
- Microsoft.Extensions.Hosting v6.0.1
- Spectre.Console v0.43.0
