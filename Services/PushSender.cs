using NotificationSystem.Interfaces;
using NotificationSystem.Models;

namespace NotificationSystem.Services;

public class PushSender : INotificationSender
{
    private readonly INotificationFormatter _formatter;
    private readonly IAppLogger _logger;

    public string Channel => "Push";

    public PushSender(INotificationFormatter formatter, IAppLogger logger)
    {
        _formatter = formatter;
        _logger = logger;
    }

    public Task SendAsync(Notification notification)
    {
        var body = _formatter.Format(notification);
        _logger.LogInfo($"[PUSH] Enviando para {notification.Recipient}");
        _logger.LogInfo(body);
        // Integração real com Firebase Cloud Messaging etc. iria aqui
        return Task.CompletedTask;
    }
}
