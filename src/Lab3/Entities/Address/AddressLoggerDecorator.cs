using Itmo.ObjectOrientedProgramming.Lab3.Entities.Address.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Address;

public class AddressLoggerDecorator : IAddress
{
    private readonly IAddress _address;
    private readonly ILogger _logger;

    public AddressLoggerDecorator(IAddress address, ILogger logger)
    {
        _address = address;
        _logger = logger;
    }

    public void SendMessage(Message message)
    {
        _logger.LogMessage($"{message.Header} \\n {message.Body}");
        _address.SendMessage(message);
    }
}