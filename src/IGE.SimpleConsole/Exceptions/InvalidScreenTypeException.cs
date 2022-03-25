namespace IGE.SimpleConsole.Exceptions;

using System;

/// <summary>
/// Thrown typicaly when an invalid type is selected as a screen.
/// Usually when it does not inherit from <see cref="Screen.ScreenBase"/>.
/// </summary>
public class InvalidScreenTypeException : Exception
{
  public InvalidScreenTypeException(Type type, string typeName)
    : base($"Invalid Screen Type: {typeName}")
  {
    this.Type = type;
    this.TypeName = typeName;
  }

  public Type Type { get; }

  public string TypeName { get; }
}
