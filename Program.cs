using Microsoft.Extensions.DependencyInjection;
using NotificationSystem.Interfaces;
using NotificationSystem.Models;
using NotificationSystem.Services;

// 1) Container de Injeção de Dependência
var services = new ServiceCollection();

// 2) Registro das abstrações -> implementações (DIP)
services.AddSingleton<IAppLogger, ConsoleLogger>();
services.AddSingleton<INotificationFormatter, DefaultNotificationFormatter>();

// 3) Múltiplas implementações do mesmo contrato (OCP)
services.AddSingleton<INotificationSender, EmailSender>();
services.AddSingleton<INotificationSender, SmsSender>();
services.AddSingleton<INotificationSender, PushSender>();

services.AddSingleton<NotificationService>();

var provider = services.BuildServiceProvider();
var notificationService = provider.GetRequiredService<NotificationService>();

// 4) Exemplo de uso
var notification = new Notification
{
    Recipient = "usuario@exemplo.com",
    Subject   = "Bem-vindo!",
    Message   = "Obrigado por se cadastrar no nosso sistema."
};

Console.WriteLine("=== Enviando apenas por Email ===");
await notificationService.NotifyAsync(notification, "Email");

Console.WriteLine("\n=== Enviando por todos os canais ===");
await notificationService.NotifyAllAsync(notification);

Console.WriteLine("\n=== Tentando canal inexistente ===");
await notificationService.NotifyAsync(notification, "Telegram");
