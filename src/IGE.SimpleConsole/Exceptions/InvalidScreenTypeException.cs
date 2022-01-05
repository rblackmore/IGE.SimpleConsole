namespace IGE.SimpleConsole.Exceptions;

using System;

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
