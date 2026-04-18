using NotificationSystem.Models;

namespace NotificationSystem.Interfaces;

public interface INotificationSender
{
    string Channel { get; }
    Task SendAsync(Notification notification);
}
