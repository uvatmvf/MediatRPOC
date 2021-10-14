using MediatR;

namespace MediatRPOC;

public class MediatRPing : IRequest<string>
{
}

public class MediatRPingHandler : IRequestHandler<MediatRPing, string>
{
    public Task<string> Handle(MediatRPing request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Pong");
    }
}

public class SomeEvent : INotification
{
    public SomeEvent(string message)
    {
        Message = message;
    }
    public string Message { get; }
}

public class Handler1 : INotificationHandler<SomeEvent>
{
    private readonly ILogger<Handler1> _logger;

    public Handler1(ILogger<Handler1> logger)
    {
        _logger = logger;
    }
    public void Handle(SomeEvent notification)
    {
        _logger.LogWarning($"Handled one: {notification.Message}");
    }

    public Task Handle(SomeEvent notification, CancellationToken cancellationToken) =>
            Task.Run(() => Handle(notification));
}
public class Handler2 : INotificationHandler<SomeEvent>
{
    private readonly ILogger<Handler2> _logger;

    public Handler2(ILogger<Handler2> logger)
    {
        _logger = logger;
    }
    public void Handle(SomeEvent notification)
    {
        _logger.LogWarning($"Handled two: {notification.Message}");
    }

    public Task Handle(SomeEvent notification, CancellationToken cancellationToken) =>
            Task.Run(() => Handle(notification));
}

