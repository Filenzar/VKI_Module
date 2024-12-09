using System;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Title} by {Author}, {Year}";
        }
    }
    public interface ISearchStrategy
    {
        IEnumerable<Book> Search(IEnumerable<Book> books, string searchTerm);
    }
    public class TitleSearchStrategy : ISearchStrategy
    {
        public IEnumerable<Book> Search(IEnumerable<Book> books, string searchTerm)
        {
            return books.Where(book => book.Title.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }

    public class AuthorSearchStrategy : ISearchStrategy
    {
        public IEnumerable<Book> Search(IEnumerable<Book> books, string searchTerm)
        {
            return books.Where(book => book.Author.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }

    public class Library
    {
        private List<Book> books = new List<Book>();
        private ISearchStrategy searchStrategy;

        public Library(ISearchStrategy searchStrategy)
        {
            this.searchStrategy = searchStrategy;
        }

        // Метод для добавления книги в библиотеку
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        // Метод для поиска книг с использованием текущей стратегии поиска
        public IEnumerable<Book> SearchBooks(string searchTerm)
        {
            return searchStrategy.Search(books, searchTerm);
        }

        // Итератор для обхода коллекции книг
        public IEnumerator<Book> GetEnumerator()
        {
            return books.GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем несколько книг
            var book1 = new Book("C# Programming", "John Doe", 2021);
            var book2 = new Book("Design Patterns", "Erich Gamma", 1994);
            var book3 = new Book("Clean Code", "Robert C. Martin", 2008);

            // Создаем библиотеку с поисковой стратегией по названию
            var library = new Library(new TitleSearchStrategy());

            // Добавляем книги в библиотеку
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            // Используем стратегию поиска по названию
            Console.WriteLine("Поиск по названию 'Code':");
            foreach (var book in library.SearchBooks("Code"))
            {
                Console.WriteLine(book);
            }

            // Создаем новую библиотеку с поисковой стратегией по автору
            library = new Library(new AuthorSearchStrategy());

            // Добавляем книги в новую библиотеку
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            // Используем стратегию поиска по автору
            Console.WriteLine("\nПоиск по автору 'Erich':");
            foreach (var book in library.SearchBooks("Erich"))
            {
                Console.WriteLine(book);
            }

            // Обход библиотеки с помощью итератора
            Console.WriteLine("\nВсе книги в библиотеке:");
            foreach (var book in library)
            {
                Console.WriteLine(book);
            }
            Console.ReadLine();
        }
    }



}
