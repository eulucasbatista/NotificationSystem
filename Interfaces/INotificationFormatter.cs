using NotificationSystem.Models;

namespace NotificationSystem.Interfaces;

public interface INotificationFormatter
{
    string Format(Notification notification);
}
