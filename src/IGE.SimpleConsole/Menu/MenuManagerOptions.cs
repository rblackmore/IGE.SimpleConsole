// <copyright file="MenuManagerOptions.cs" company="Ryan Blackmore">.
// Copyright © 2021 Ryan Blackmore. All rights Reserved.
// </copyright>

namespace IGE.SimpleConsole.Menu;

/// <summary>
/// Options for configuration Menu Behaviour.
/// </summary>
public class MenuManagerOptions
{
  /// <summary>
  /// Gets or Sets the Title for the console Window.
  /// </summary>
  public string WindowTitle { get; set; }

  /// <summary>
  /// Gets or Sets a value indicating whether menu breadcrumbs will be displayed.
  /// </summary>
  public bool BreadCrumbHeader { get; set; } = false;
}
