using NotificationSystem.Interfaces;
using NotificationSystem.Models;

namespace NotificationSystem.Services;

public class DefaultNotificationFormatter : INotificationFormatter
{
    public string Format(Notification notification)
    {
        return $"[{notification.CreatedAt:yyyy-MM-dd HH:mm}] {notification.Subject}\n{notification.Message}";
    }
}
