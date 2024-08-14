using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Address;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Address.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.User;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.User.UserMessage;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessengerTest
{
    [Fact]
#pragma warning disable CA1707
    public void SendMessage_ShouldBeReceivedWithReadStatusFalse_Always()
#pragma warning restore CA1707
    {
        // Arrange
        var message = new Message("MyMessage", "body", 3);
        var user = new User(5);
        var address = new UserAddress(user);
        var topic = new Topic("Some topic", address);

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.False(user.FindMessage("MyMessage")?.Read);
    }

    [Fact]
#pragma warning disable CA1707
    public void SetUserMessageRead_ReadStatusShouldBeSetTrue_WhenUserReadIt()
#pragma warning restore CA1707
    {
        // Arrange
        var message = new Message("MyMessage", "body", 3);
        var user = new User(5);
        var address = new UserAddress(user);
        var topic = new Topic("Some topic", address);

        // Act
        topic.SendMessage(message);
        user.SetMessageRead("MyMessage");

        // Assert
        Assert.True(user.FindMessage("MyMessage")?.Read);
    }

    [Fact]
#pragma warning disable CA1707
    public void SetReadUserMessageRead_FailStatusShouldAppear_WhenSetReadMessageReadStatusTrue()
#pragma warning restore CA1707
    {
        // Arrange
        var message = new Message("MyMessage", "body", 3);
        var user = new User(5);
        var address = new UserAddress(user);
        var topic = new Topic("Some topic", address);

        // Act
        topic.SendMessage(message);
        user.SetMessageRead("MyMessage");

        // Assert
        Assert.Equal(typeof(ReadStatusState.Fail), user.SetMessageRead("MyMessage").GetType());
    }

    [Fact]
#pragma warning disable CA1707
    public void SendMessage_ShouldBeIgnored_WhenPriorityIsLow()
#pragma warning restore CA1707
    {
        // Arrange
        var message = new Message("MyMessage1", "body", 2);
        IUser? user = Substitute.For<IUser>();
        IAddress address = new ImportanceAddress(new UserAddress(user), 3);
        var topic = new Topic("Some topic", address);

        // Act
        topic.SendMessage(message);

        // Assert
        user.DidNotReceive().GetMessage(Arg.Any<Message>());
    }

    [Fact]
#pragma warning disable CA1707
    public void LogSendMessage_ShouldBeLogged_WhenLoggerExists()
#pragma warning restore CA1707
    {
        // Arrange
        var message1 = new Message("MyMessage", "body", 3);
        ILogger logger = Substitute.For<ILogger>();
        var topic = new Topic("Some topic", new AddressLoggerDecorator(new UserAddress(new User(1)), logger));

        // Act
        topic.SendMessage(message1);

        // Assert
        logger.Received().LogMessage(Arg.Any<string>());
    }

    [Fact]
#pragma warning disable CA1707
    public void MessengerSetMessage_ShouldBeSet_WhenMessengerGetMessage()
#pragma warning restore CA1707
    {
        // Arrange
        var message1 = new Message("MyMessage", "body", 3);
        IMessengerPrinter? printer = Substitute.For<IMessengerPrinter>();
        IMessenger messenger = new Messenger(printer);
        IAddress address = new MessengerAddress(messenger);
        var topic = new Topic("Some topic", address);

        // Act
        topic.SendMessage(message1);

        // Assert
        printer.Received().Print(Arg.Any<MessengerMessage>());
    }
}