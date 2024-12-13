using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    using System;
    using System.Collections.Generic;

    // Интерфейс для медиатора
    public interface IChatMediator
    {
        void SendMessage(string message, User sender, string receiverName);
        void AddUser(User user);
    }

    // Класс медиатора
    public class ChatMediator : IChatMediator
    {
        private List<User> _users;

        public ChatMediator()
        {
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void SendMessage(string message, User sender, string receiverName)
        {
            User receiver = _users.Find(u => u.Name == receiverName);
            if (receiver != null)
            {
                receiver.ReceiveMessage(message, sender.Name);
            }
        }
    }

    // Класс пользователя
    public class User
    {
        public string Name { get; private set; }
        private IChatMediator _mediator;
        private List<string> _messageHistory;

        public User(string name, IChatMediator mediator)
        {
            Name = name;
            _mediator = mediator;
            _messageHistory = new List<string>();
            _mediator.AddUser(this);
        }

        public void SendMessage(string message, string receiverName)
        {
            Console.WriteLine($"{Name} отправляет сообщение '{message}' пользователю {receiverName}");
            _mediator.SendMessage(message, this, receiverName);
        }

        public void ReceiveMessage(string message, string senderName)
        {
            Console.WriteLine($"{Name} получил сообщение от {senderName}: '{message}'");
            _messageHistory.Add($"{senderName}: {message}");
        }

        public void ShowMessageHistory()
        {
            Console.WriteLine($"История сообщений для {Name}:");
            foreach (var msg in _messageHistory)
            {
                Console.WriteLine(msg);
            }
        }
    }

    // Пример использования
    public class Program
    {
        public static void Main(string[] args)
        {
            ChatMediator chatMediator = new ChatMediator();

            User user1 = new User("Alice", chatMediator);
            User user2 = new User("Bob", chatMediator);
            User user3 = new User("Charlie", chatMediator);

            user1.SendMessage("Привет, Боб!", "Bob");
            user2.SendMessage("Привет, Алиса!", "Charlie");
            user3.SendMessage("Привет всем!", "Alice");

            user1.ShowMessageHistory();
            user2.ShowMessageHistory();
            user3.ShowMessageHistory();
            Console.ReadLine();
        }
    }

}
