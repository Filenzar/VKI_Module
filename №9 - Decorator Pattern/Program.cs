using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface INotifier
{
    void Send(string message);
}

public class Email : INotifier
{
    private readonly string _email;

    public Email(string email)
    {
        _email = email;
    }

    public void Send(string message)
    {
        Console.WriteLine($"Email отправлен на {_email}: {message}");
    }
}

public abstract class NotifierDecorator : INotifier
{
    protected readonly INotifier _notifier;

    public NotifierDecorator(INotifier notifier)
    {
        _notifier = notifier;
    }

    public virtual void Send(string message)
    {
        _notifier.Send(message);
    }
}


public class SmsNotifier : NotifierDecorator
{
    public SmsNotifier(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"SMS отправлено: {message}");
    }
}

public class FacebookNotifier : NotifierDecorator
{
    public FacebookNotifier(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Сообщение отправлено на Facebook: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Email
        INotifier emailNotifier = new Email("admin@example.com");

        // SMS
        INotifier smsNotifier = new SmsNotifier(emailNotifier);

        // Facebook
        INotifier facebookNotifier = new FacebookNotifier(smsNotifier);

        facebookNotifier.Send("Вам пришло сообщение.");
        Console.ReadLine();
    }
}