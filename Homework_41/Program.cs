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
                    storage.Add();
                    break;
                case DeletingBook:
                    storage.Delete();
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
    public string Name;

    public string Author;

    public int ReleaseDate;


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

    public void Add()
    {
        Console.WriteLine("Введите название книги:");
        string name = Console.ReadLine();

        Console.WriteLine("Введите имя автора книги:");
        string author = Console.ReadLine();

        Console.WriteLine("Введите год выхода книги:");
        bool isNumber = int.TryParse(Console.ReadLine(), out int date);

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

    public void Delete()
    {
        if (TryGetBook(out Book book))
        {
            _books.Remove(book);
        }
    }

    public bool TryGetBook(out Book book)
    {
        Console.WriteLine("Введите индекс книги:");
        bool isNumber = int.TryParse(Console.ReadLine(), out int index);

        if (index > 0 && index - 1 < _books.Count)
        {
            book = _books[index - 1];
            Console.WriteLine("Книга удалена!");
            return false;
        }
        else if (isNumber == false)
        {
            Console.WriteLine("Ошибка!");
            book = null;
            return false;
        }
        else
        {
            Console.WriteLine("Книга с таким индексом отсутствует!");
            book = null;
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
            ShowAll();
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

    public void ShowAll()
    {
        foreach (var book in _books)
        {
            Console.WriteLine($"Книга: {book.Name}. Автор: {book.Author}. Год выпуска: {book.ReleaseDate}");
        }
    }

    public void FindForParameters()
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

    public void FindName()
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

    public void FindAuthor()
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

    public void FindDate()
    {
        Console.WriteLine("Укажите дату выхода книги:");
        int date = Convert.ToInt32(Console.ReadLine());

        foreach (var book in _books)
        {
            if (date == book.ReleaseDate)
            {
                Console.WriteLine($"Книга: {book.Name}. Автор: {book.Author}. Год выпуска: {book.ReleaseDate}");
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }
        }
    }
}