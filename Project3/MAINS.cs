using System;

class Program
{
    static void Main()
    {
        Library<Book> bookLibrary = new Library<Book>();
        bookLibrary.Add(new Book("Игра престола", "George Martin", 1996, 694, "Фантастика"));
        bookLibrary.Add(new Book("Гарри Поттер", "Rowling", 1997, 432, "Фэнтези"));


        Library<Movie> movieLibrary = new Library<Movie>();
        movieLibrary.Add(new Movie("Дюна", "Denis V", 2021, 155, "не помню"));
        movieLibrary.Add(new Movie("Джокер", "Todd P", 2019, 122, "не помню"));

        Library<MusicAlbum> musicLibrary = new Library<MusicAlbum>();
        musicLibrary.Add(new MusicAlbum("Home", "Toby Fox", 2015, "Toby Fox", 7));
        musicLibrary.Add(new MusicAlbum("Blinding Lights", "The Weeknd", 2019, "The Weeknd", 4));

        while (true)
        {
            Console.WriteLine("\nВыберите опцию: 1-поиск, 2-выдача/покупка(заменяет IsAvailable = true/false), 3-возврат, 4-вывести все, 5-выход");
            string choice = Console.ReadLine();

            if (choice == "5") break;

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название: ");
                        string title = Console.ReadLine();
                        Media foundItem = bookLibrary.FindByTitle(title) as Media ??
                                           movieLibrary.FindByTitle(title) as Media ??
                                           musicLibrary.FindByTitle(title) as Media;
                        Console.WriteLine(foundItem?.ToString() ?? "Элемент не найден.");
                        break;
                    case "2":
                        Console.Write("Введите название: ");
                        title = Console.ReadLine();
                        bookLibrary.CheckOut(title);
                        Console.WriteLine("Выдача выполнена успешно.");
                        break; //не получилось добавить музыку т.к не получилось добавить true/false
                    case "3":
                        Console.Write("Введите название: ");
                        title = Console.ReadLine();
                        bookLibrary.Return(title);
                        Console.WriteLine("Возврат выполнен успешно.");
                        break;
                    case "4":
                        Console.WriteLine("Книги:");
                        bookLibrary.PrintAll();
                        Console.WriteLine("\nФильмы:");
                        movieLibrary.PrintAll();
                        Console.WriteLine("\nМуз. Альбомы:");
                        musicLibrary.PrintAll();
                        break;
                    default:
                        Console.WriteLine("Выберите число ИЗ перечисленных");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}