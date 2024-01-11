using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Events.PaymentSuccessfulEvent;

public class PaymentSuccessfulEvent : INotification
{
    public string FirstName { get; }
    public string Email { get; }
    public string TransactionCode { get; }
    public PaymentSuccessfulEvent(string firstName, string email, string transactionCode)
    {
        FirstName = firstName;
        Email = email;
        TransactionCode = transactionCode;
    }
}

public class PaymentSuccessfulEventHandler : INotificationHandler<PaymentSuccessfulEvent>
{
    private readonly ILogger<PaymentSuccessfulEventHandler> _logger;
    public Task Handle(PaymentSuccessfulEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Dear {notification.FirstName} your payment with Code {notification.TransactionCode} done!");
        return Task.CompletedTask;
    }
}