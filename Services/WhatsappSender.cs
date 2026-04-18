using NotificationSystem.Interfaces;
using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Services
{
    public class WhatsappSender : INotificationSender
    {
        private readonly INotificationFormatter _formatter;
        private readonly IAppLogger _logger;

        public string Channel => "Whatsapp";

        public WhatsappSender(INotificationFormatter formatter, IAppLogger logger)
        {
            _formatter = formatter;
            _logger = logger;
        }

        public Task SendAsync(Notification notification)
        {
            var body = _formatter.Format(notification);
            _logger.LogInfo($"[WHATSAPP] Enviando para {notification.Recipient}");
            _logger.LogInfo(body);
            // Aqui entraria a integração real (SMTP, SendGrid, etc.)
            return Task.CompletedTask;
        }
    }
}
