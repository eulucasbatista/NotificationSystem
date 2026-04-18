using NotificationSystem.Interfaces;
using NotificationSystem.Models;

namespace NotificationSystem.Services;

public class NotificationService
{
    private readonly IEnumerable<INotificationSender> _senders;
    private readonly IAppLogger _logger;

    public NotificationService(IEnumerable<INotificationSender> senders, IAppLogger logger)
    {
        _senders = senders;
        _logger = logger;
    }

    public async Task NotifyAsync(Notification notification, string channel)
    {
        var sender = _senders.FirstOrDefault(
            s => s.Channel.Equals(channel, StringComparison.OrdinalIgnoreCase));

        if (sender is null)
        {
            _logger.LogError($"Canal '{channel}' não suportado.");
            return;
        }

        try
        {
            await sender.SendAsync(notification);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Falha ao enviar via {channel}", ex);
        }
    }

    public async Task NotifyAllAsync(Notification notification)
    {
        foreach (var sender in _senders)
        {
            await NotifyAsync(notification, sender.Channel);
        }
    }
}
