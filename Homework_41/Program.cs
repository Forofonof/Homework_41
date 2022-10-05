using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        const string AddingBook = "1";
        const string DeletingBook = "2";
        const string ShowAllBooks = "3";
        const string Exit = "4";

        Storage storage = new Storage();

        bool isWork = true;

        Console.WriteLine("Хранилище книг к вашим услугам!\nЧто желаете сделать?");

        while (isWork)
        {
            Console.WriteLine($"\n{AddingBook} - Добавить книгу.\n{DeletingBook} - Удалить книгу.\n{ShowAllBooks} - Показать все книги.\n{Exit} - Выход.\n");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case AddingBook:
                    storage.AddBook();
                    break;
                case DeletingBook:
                    storage.DeleteBook();
                    break;
                case ShowAllBooks:
                    storage.Show();
                    break;
                case Exit:
                   isWork = false;
                    break;
                default:
                    Console.WriteLine("Ошибка! Нет такой команды.");
                    break;
            }
        }
    }
}

class Book
{
    public string Name { get; private set; }

    public string Author { get; private set; }

    public int ReleaseDate { get; private set; }

    public Book(string name, string author, int releaseDate)
    {
        Name = name;
        Author = author;
        ReleaseDate = releaseDate;
    }
}

class Storage
{
    private const string SearchForName = "1";
    private const string SearchForAuthor = "2";
    private const string SearchForDate = "3";

    private List<Book> _books = new List<Book>();

    public Storage()
    {
        _books.Add(new Book("Голубая книга", "Михаил Зощенко", 1935));
        _books.Add(new Book("Бедные люди", "Фёдор Достоевский", 1865));
        _books.Add(new Book("О скоротечности жизни", "Анней Сенека", 55));
    }

    public void AddBook()
    {
        Console.WriteLine("Введите название книги:");
        string name = Console.ReadLine();

        Console.WriteLine("Введите имя автора книги:");
        string author = Console.ReadLine();

        Console.WriteLine("Введите год выхода книги:");
        ReadNumber(out bool isNumber, out int date);

        if (isNumber == true)
        {
            Book book = new Book(name, author, date);
            _books.Add(book);
            Console.WriteLine("Книга добавлена в хранилище!");
        }
        else
        {
            Console.WriteLine("Ошибка!");
            return;
        }
    }

    public void DeleteBook()
    {
        if (TryGetBook(out Book book))
        {
            _books.Remove(book);
            Console.WriteLine("Книга удалена!");
        }
    }

    public bool TryGetBook(out Book book)
    {
        Console.WriteLine("Введите индекс книги:");
        bool isNumber = int.TryParse(Console.ReadLine(), out int index);

        if (index > 0 && index - 1 < _books.Count && isNumber == true)
        {
            book = _books[index - 1];
            return false;
        }
        else
        {
            book = null;
            Console.WriteLine("Ошибка!");
            return false;
        }
    }

    public void Show()
    {
        string showAllBooks = "1";
        string searchForParameters = "2";

        Console.WriteLine($"{showAllBooks} - Показать все книги.\n{searchForParameters} - Поиск книги по параметрам.");
        string userInput = Console.ReadLine();

        if (userInput == showAllBooks)
        {
            ShowAllBooks();
        }
        else if (userInput == searchForParameters)
        {
            FindForParameters();
        }
        else
        {
            Console.WriteLine("Ошибка!");
        }
    }

    private void ShowAllBooks()
    {
        foreach (var book in _books)
        {
            Console.WriteLine($"Книга: {book.Name}. Автор: {book.Author}. Год выпуска: {book.ReleaseDate}");
        }
    }

    private void FindForParameters()
    {
        Console.WriteLine($"\n{SearchForName} - Поиск по названию книги.\n{SearchForAuthor} - Поиск по автору.'\n{SearchForDate} - Поиск по дате выхода.\n");
        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case SearchForName:
                FindName();
                break;
            case SearchForAuthor:
                FindAuthor();
                break;
            case SearchForDate:
                FindDate();
                break;
            default:
                Console.WriteLine("Ошибка! Нет такой команды.");
                break;
        }
    }

    private void FindName()
    {
        Console.WriteLine("Укажите название книги:");
        string name = Console.ReadLine();

        foreach (var book in _books)
        {
            if (name.ToLower() == book.Name.ToLower())
            {
                Console.WriteLine($"Книга: {book.Name}. Автор: {book.Author}. Год выпуска: {book.ReleaseDate}");
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }
        }
    }

    private void FindAuthor()
    {
        Console.WriteLine("Укажите Имя и Фамилию автора:");
        string author = Console.ReadLine();

        foreach (var book in _books)
        {
            if (author.ToLower() == book.Author.ToLower())
            {
                Console.WriteLine($"Книга: {book.Name}. Автор: {book.Author}. Год выпуска: {book.ReleaseDate}");
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }
        }
    }

    private void FindDate()
    {
        Console.WriteLine("Укажите дату выхода книги:");
        ReadNumber(out bool isNumber, out int date);

        foreach (var book in _books)
        {
            if (date == book.ReleaseDate && isNumber == true)
            {
                Console.WriteLine($"Книга: {book.Name}. Автор: {book.Author}. Год выпуска: {book.ReleaseDate}");
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }
        }
    }

    private void ReadNumber(out bool isNumber, out int date)
    {
        isNumber = int.TryParse(Console.ReadLine(), out date);
    }
}