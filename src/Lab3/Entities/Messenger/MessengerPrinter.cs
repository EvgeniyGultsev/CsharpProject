using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class MessengerPrinter : IMessengerPrinter
{
    public void Print(MessengerMessage message)
    {
        Console.WriteLine("Messenger:");
        Console.WriteLine(message.Header);
        Console.WriteLine(message.Body);
    }
}