using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CompositePattern
{
    public interface IDocumentComponent
    {
        void Add(IDocumentComponent component);
        void Remove(IDocumentComponent component);
        void Display(int indent);   // indent - длина отступа
    }
    public class Paragraph : IDocumentComponent
    {
        private string _text;

        public Paragraph(string text)
        {
            _text = text;
        }

        public void Add(IDocumentComponent component)
        {
            throw new NotImplementedException("Не возможно добавление в параграф.");
        }

        public void Remove(IDocumentComponent component)
        {
            throw new NotImplementedException("Не возможно удаление из параграфа.");
        }

        public void Display(int indent)
        {
            Console.WriteLine(new string(' ', indent) + _text);
        }
    }
    public class Section : IDocumentComponent
    {
        private string _title;
        private List<IDocumentComponent> _components;

        public Section(string title)
        {
            _title = title;
            _components = new List<IDocumentComponent>();
        }

        public void Add(IDocumentComponent component)
        {
            if (component is Document)
            {
                throw new NotImplementedException("Невозможно добавить элемент типа Document в раздел.");
            }
            _components.Add(component); 
        }

        public void Remove(IDocumentComponent component)
        {
            _components.Remove(component);
        }

        public void Display(int indent)
        {
            Console.WriteLine(new string(' ', indent) + _title);
            foreach (var component in _components)
            {
                component.Display(indent + 2); // Увеличиваем отступ для дочерних компонентов
            }
        }
    }
    public class Document : IDocumentComponent
    {
        private List<IDocumentComponent> _sections;

        public Document()
        {
            _sections = new List<IDocumentComponent>();
        }

        public void Add(IDocumentComponent section)
        {
            _sections.Add(section);
        }

        public void Remove(IDocumentComponent section)
        {
            _sections.Remove(section);
        }

        public void Display(int indent = 0)
        {
            foreach (var section in _sections)
            {
                section.Display(0); // Начинаем отображение без отступов
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();

            Section section1 = new Section("Введение");
            section1.Add(new Paragraph("Это первый абзац введения."));
            section1.Add(new Paragraph("Это второй абзац введения."));

            Section section2 = new Section("Основная часть");
            section2.Add(new Paragraph("Это абзац основная части."));
            Section chapter1 = new Section("Глава 1");
            chapter1.Add(new Paragraph("Это абзац первой главы."));
            Section chapter2 = new Section("Глава 2");
            chapter2.Add(new Paragraph("Это абзац второй главы."));

            section2.Add(chapter1);
            section2.Add(chapter2);


            Section subsection = new Section("Подраздел");
            subsection.Add(new Paragraph("Это первый абзац в подразделе."));
            subsection.Add(new Paragraph("Это второй абзац в подразделе."));
            section2.Add(subsection);

            document.Add(section1);
            document.Add(section2);
            
            document.Display();
            Console.ReadLine();
        }
    }
}
