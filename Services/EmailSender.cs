using NotificationSystem.Interfaces;
using NotificationSystem.Models;

namespace NotificationSystem.Services;

public class EmailSender : INotificationSender
{
    private readonly INotificationFormatter _formatter;
    private readonly IAppLogger _logger;

    public string Channel => "Email";

    public EmailSender(INotificationFormatter formatter, IAppLogger logger)
    {
        _formatter = formatter;
        _logger = logger;
    }

    public Task SendAsync(Notification notification)
    {
        var body = _formatter.Format(notification);
        _logger.LogInfo($"[EMAIL] Enviando para {notification.Recipient}");
        _logger.LogInfo(body);
        // Aqui entraria a integração real (SMTP, SendGrid, etc.)
        return Task.CompletedTask;
    }
}
