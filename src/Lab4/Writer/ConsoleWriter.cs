using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Writer;

public class ConsoleWriter : IWriter
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}