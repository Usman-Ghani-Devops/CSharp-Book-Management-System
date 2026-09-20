using System;

namespace BookManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        BookDataAccess dal = new BookDataAccess();
        while (true)
        {
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Find Book by ID");
            Console.WriteLine("4. Create Backup");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter the Option");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    add_book_func(dal);
                    break;
                case "2":
                    view_all_books_func(dal);
                    break;
                case "3":
                    find_by_id_func(dal);
                    break;
                case "4":
                    backup_func(dal);
                    break;
                case "5":
                    Console.WriteLine("Exiting");
                    return;
                default:
                    Console.WriteLine("Invalid Option");
                    break;

            }
        }
    }

    static void add_book_func(BookDataAccess dal)
    {

        Console.WriteLine("Enter the id");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the title");
        string? title = Console.ReadLine();
        Console.WriteLine("Enter the author");
        string? author = Console.ReadLine();
        Console.WriteLine("Enter the price");
        double price = double.Parse(Console.ReadLine());

        Book book = new Book(id, title, author, price);
        bool value = dal.add_book(book);

        if (value)
        {
            Console.WriteLine("Book Added Sucessfully");
        }
        else
        {
            Console.WriteLine("Book doesnot added Sucessfully");
        }
    }

    static void view_all_books_func(BookDataAccess dal)
    {
        List<Book> books = dal.view_all_books();

        if (books.Count == 0)
        {
            Console.WriteLine("No books found");
            return;
        }
        else
        {
            foreach (Book book in books)
            {
                book.DisplayInfo();
            }
        }
    }

    static void find_by_id_func(BookDataAccess dal)
    {
        Console.WriteLine("Enter the id of the book");
        int id = int.Parse(Console.ReadLine());
        Book book = dal.find_book_by_id(id);
        if (book == null)
        {
            Console.WriteLine("No Book Found");
        }
        else
        {
            book.DisplayInfo();
        }
    }

    static void backup_func(BookDataAccess dal)
    {
        bool value = dal.CreateBackup();

        if (value)
        {
            Console.WriteLine("Backup Created successfully"); ;
        }
        else
        {

            Console.WriteLine("No Backup Created");
        }
    }

}