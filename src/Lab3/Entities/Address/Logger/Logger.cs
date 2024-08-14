using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Address.Logger;

public class Logger : ILogger
{
    private readonly IList<string> _logs = new List<string>();
    public int LogsCount => _logs.Count;

    public void LogMessage(string message)
    {
        _logs.Add(message);
    }
}