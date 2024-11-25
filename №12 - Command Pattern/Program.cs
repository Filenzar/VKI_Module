using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class InsertTextCommand : ICommand
    {
        private TextEditor _textEditor;
        private string _textToInsert;

        public InsertTextCommand(TextEditor textEditor, string text)
        {
            _textEditor = textEditor;
            _textToInsert = text;
        }

        public void Execute()
        {
            _textEditor.InsertText(_textToInsert);
        }

        public void Undo()
        {
            _textEditor.DeleteText(_textToInsert.Length);
        }
    }
    public class DeleteTextCommand : ICommand
    {
        private TextEditor _textEditor;
        private int _lengthToDelete;
        private string _deletedText;

        public DeleteTextCommand(TextEditor textEditor, int length)
        {
            _textEditor = textEditor;
            _lengthToDelete = length;
        }

        public void Execute()
        {
            _deletedText = _textEditor.DeleteText(_lengthToDelete);
        }

        public void Undo()
        {
            _textEditor.InsertText(_deletedText);
        }
    }

    public class TextEditor
    {
        private string _text = "";
        private Stack<ICommand> _commandHistory = new Stack<ICommand>();

        // Метод для вставки текста
        public void InsertText(string text)
        {
            _text += text;
            Console.WriteLine("Текст после вставки: " + _text);
        }

        // Метод для удаления текста
        public string DeleteText(int length)
        {
            if (length > _text.Length)
            {
                length = _text.Length;
            }

            string deletedText = _text.Substring(_text.Length - length, length);
            _text = _text.Substring(0, _text.Length - length);
            Console.WriteLine("Текст после удаления: " + _text);
            return deletedText;
        }

        // Метод для выполнения команды
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);  // Добавляем команду в историю
        }

        // Метод для отмены последней команды
        public void Undo()
        {
            if (_commandHistory.Count > 0)
            {
                ICommand lastCommand = _commandHistory.Pop();
                lastCommand.Undo();
            }
            else
            {
                Console.WriteLine("Нет команд для отмены.");
            }
        }

        // Метод для отображения текущего текста
        public string GetText()
        {
            return _text;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();

            // Ввод текста
            ICommand insertHello = new InsertTextCommand(editor, "Hello ");
            ICommand insertWorld = new InsertTextCommand(editor, "World!");

            editor.ExecuteCommand(insertHello);  // Вставляем "Hello"
            editor.ExecuteCommand(insertWorld);  // Вставляем "World!"


            // Удаление текста
            ICommand deleteWorld = new DeleteTextCommand(editor, 6);  // Удаляем "World!"
            editor.ExecuteCommand(deleteWorld);


            // Отмена последней операции (удаление)
            editor.Undo();

            // Отмена операции вставки
            editor.Undo();
        }
    }


}
