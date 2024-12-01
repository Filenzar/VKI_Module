using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility
{
    // Абстрактный класс обработчика
    public abstract class EventHandler
    {
        protected EventHandler nextHandler; // Следующий обработчик в цепочке

        public EventHandler(EventHandler nextHandler = null)
        {
            this.nextHandler = nextHandler;
        }

        public abstract void Handle(Event eventItem);
    }

    // Конкретные обработчики

    public class ButtonClickHandler : EventHandler
    {
        public ButtonClickHandler(EventHandler nextHandler = null) : base(nextHandler) { }

        public override void Handle(Event eventItem)
        {
            if (eventItem.Type == "button_click")
            {
                Console.WriteLine("Обработчик ButtonClickHandler: Обработан клик по кнопке.");
            }
            else if (nextHandler != null)
            {
                nextHandler.Handle(eventItem);
            }
        }
    }

    public class KeyPressHandler : EventHandler
    {
        public KeyPressHandler(EventHandler nextHandler = null) : base(nextHandler) { }

        public override void Handle(Event eventItem)
        {
            if (eventItem.Type == "key_press")
            {
                Console.WriteLine("Обработчик KeyPressHandler: Обработано нажатие клавиши.");
            }
            else if (nextHandler != null)
            {
                nextHandler.Handle(eventItem);
            }
        }
    }

    public class MouseMoveHandler : EventHandler
    {
        public MouseMoveHandler(EventHandler nextHandler = null) : base(nextHandler) { }

        public override void Handle(Event eventItem)
        {
            if (eventItem.Type == "mouse_move")
            {
                Console.WriteLine("Обработчик MouseMoveHandler: Обработано движение мыши.");
            }
            else if (nextHandler != null)
            {
                nextHandler.Handle(eventItem);
            }
        }
    }

    // Класс запроса
    public class Event
    {
        public string Type { get; set; }
        public string Content { get; set; }

        public Event(string type, string content)
        {
            Type = type;
            Content = content;
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Создаем цепочку обработчиков
            EventHandler handlerChain = new ButtonClickHandler(
                new KeyPressHandler(
                    new MouseMoveHandler()
                )
            );

            // Пример тестирования
            TestChainOfResponsibility(handlerChain);
        }

        public static void TestChainOfResponsibility(EventHandler handlerChain)
        {
            var events = new[]
            {
                new Event("button_click", "Кнопка нажата"),
                new Event("key_press", "Клавиша нажата"),
                new Event("mouse_move", "Мышь перемещена")
            };

            foreach (var eventItem in events)
            {
                Console.WriteLine($"\nОбработка события: {eventItem.Type}");
                handlerChain.Handle(eventItem);
            }
        }
    }

}
