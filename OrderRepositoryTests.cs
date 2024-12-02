namespace OrderService.Tests;

using System;
using Xunit;

public class OrderRepositoryTests
{
    [Fact]
    public void ProcessPayment_SuccessfulSwishPayment_ShouldSetIsPaidToTrue()
    {
        // Arrange
        var order = new Order
        {
            Id = 1,
            TotalAmount = 100m,
            PaymentMethod = PaymentMethod.Swish,
            IsPaid = false
        };
        var repository = new OrderRepository();

        // Act
        var result = repository.ProcessPayment(order);

        // Assert
        Assert.True(result);
        Assert.True(order.IsPaid);
    }

    [Fact]
    public void ProcessPayment_UnsupportedPaymentMethod_ShouldThrowException()
    {
        // Arrange
        var order = new Order
        {
            Id = 1,
            PaymentMethod = (PaymentMethod)999
        };
        var repository = new OrderRepository();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => repository.ProcessPayment(order));
    }
}
