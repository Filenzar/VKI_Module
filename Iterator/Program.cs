using System;
using System.Collections;
using System.Collections.Generic;

// Класс книги
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

// Итератор для книги
public class LibraryIterator : IEnumerator<Book>
{
    private Library _library;
    private int _currentIndex = -1;

    public LibraryIterator(Library library)
    {
        _library = library;
    }

    public Book Current => _library.GetBookAt(_currentIndex);

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _currentIndex++;
        return _currentIndex < _library.Count;
    }

    public void Reset()
    {
        _currentIndex = -1;
    }

    public void Dispose() { }
}

// Класс библиотеки, который использует Итератор
public class Library : IEnumerable<Book>
{
    private List<Book> _books;

    public Library()
    {
        _books = new List<Book>();
    }

    // Метод для добавления книги в библиотеку
    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    // Метод для получения книги по индексу
    public Book GetBookAt(int index)
    {
        if (index >= 0 && index < _books.Count)
        {
            return _books[index];
        }
        return null;
    }

    // Свойство для получения количества книг
    public int Count => _books.Count;

    // Метод, который возвращает итератор для обхода
    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this);
    }

    // Необходимая для реализации IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        // Создаем библиотеку
        Library library = new Library();

        // Добавляем книги
        library.AddBook(new Book("1984", "George Orwell", 1949));
        library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", 1960));
        library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925));

        // Используем итератор для обхода книг
        foreach (var book in library)
        {
            Console.WriteLine(book);
        }
        Console.ReadLine();
    }
}
