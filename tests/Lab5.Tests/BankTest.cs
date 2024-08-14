using System.Threading.Tasks;
using Abstractions.Repositories;
using Application.UserActions;
using Contracts;
using Contracts.UserActions;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankTest
{
    [Fact]
#pragma warning disable CA1707
    public async Task SubtractMoney_ShouldReturnFail_IfNotEnoughMoney()
#pragma warning restore CA1707
    {
        // Arrange
        ICardRepository cardRepository = Substitute.For<ICardRepository>();
        cardRepository.ShowBalanceById(1234).Returns(10);
        ISubtractMoney subtract = new SubtractMoneyAction(cardRepository, Substitute.For<IOperationsRepository>());

        // Act
        OperationResult result = await subtract.SubtractMoney(1234, 20);

        // Assert
        Assert.Equal(typeof(OperationResult.Fail), result.GetType());
    }

    [Fact]
#pragma warning disable CA1707
    public async Task SubtractMoney_ShouldReturnSuccess_IfEnoughMoney()
#pragma warning restore CA1707
    {
        // Arrange
        ICardRepository cardRepository = Substitute.For<ICardRepository>();
        cardRepository.ShowBalanceById(1234).Returns(10);
        cardRepository.SubtractMoney(1234, 5).Returns(new OperationResult.Success());
        ISubtractMoney subtract = new SubtractMoneyAction(cardRepository, Substitute.For<IOperationsRepository>());

        // Act
        OperationResult result = await subtract.SubtractMoney(1234, 5);

        // Assert
        Assert.Equal(typeof(OperationResult.Success), result.GetType());
    }

    [Fact]
#pragma warning disable CA1707
    public async Task AddMoney_ShouldReturnSuccess_Always()
#pragma warning restore CA1707
    {
        // Arrange
        ICardRepository cardRepository = Substitute.For<ICardRepository>();
        cardRepository.AddMoney(1234, 5).Returns(new OperationResult.Success());
        IAddMoney add = new AddMoneyAction(cardRepository, Substitute.For<IOperationsRepository>());

        // Act
        OperationResult result = await add.AddMoney(1234, 5);

        // Assert
        Assert.Equal(typeof(OperationResult.Success), result.GetType());
    }
}