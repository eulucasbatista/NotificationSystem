using NotificationSystem.Interfaces;
using NotificationSystem.Models;

namespace NotificationSystem.Services;

public class SmsSender : INotificationSender
{
    private readonly INotificationFormatter _formatter;
    private readonly IAppLogger _logger;

    public string Channel => "SMS";

    public SmsSender(INotificationFormatter formatter, IAppLogger logger)
    {
        _formatter = formatter;
        _logger = logger;
    }

    public Task SendAsync(Notification notification)
    {
        var body = _formatter.Format(notification);
        _logger.LogInfo($"[SMS] Enviando para {notification.Recipient}");
        _logger.LogInfo(body);
        // Integração real com Twilio, Zenvia etc. iria aqui
        return Task.CompletedTask;
    }
}
