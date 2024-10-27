using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public interface INotificationSender
    {
        void Send(string message);
    }
    public class SmsSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Отправка SMS: {message}");
        }
    }
    public class EmailSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Отправка Email: {message}");
        }
    }
    public class HTMLSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Отправка HTML: {message}");
        }
    }



    public abstract class Notification
    {
        protected INotificationSender _notificationSender;

        protected Notification(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }

        public abstract void Notify(string message);
    }
    public class TextNotification : Notification
    {
        public TextNotification(INotificationSender notificationSender) : base(notificationSender) { }

        public override void Notify(string message)
        {
            _notificationSender.Send($"\n     Текстовое сообщение:{message}\n");
        }
    }
    public class HtmlNotification : Notification
    {
        public HtmlNotification(INotificationSender notificationSender) : base(notificationSender) { }

        public override void Notify(string message)
        {
            _notificationSender.Send($"\n     HTML уведомление:{message}");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            INotificationSender SmsSender = new SmsSender();
            INotificationSender EmailSender = new EmailSender();
            Notification SMS = new TextNotification(SmsSender);
            Notification Email = new TextNotification(EmailSender);

            INotificationSender HTMLSender = new HTMLSender();
            Notification HTML = new HtmlNotification(HTMLSender);

            SMS.Notify("Кто?");
            Email.Notify("Я");
            HTML.Notify("Ты");
            Console.ReadLine();
        }
    }
}
