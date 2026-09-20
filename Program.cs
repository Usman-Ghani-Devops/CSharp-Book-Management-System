namespace BookManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book(1, "C#", "Welbert", 1200);
        BookDataAccess book1dal = new BookDataAccess();

        book1dal.add_book(book1);

        List<Book> books = book1dal.view_all_books();

        if (books.Count == 0)
        {
            Console.WriteLine("No books found");
        }

        foreach (Book book in books)
        {
            book.DisplayInfo();
        }

        Book? bk = book1dal.find_book_by_id(1);

        if (bk == null)
        {
            Console.WriteLine("No book Found");
        }
        else
        {
            bk.DisplayInfo();   
        }

        bool value = book1dal.CreateBackup();
        if (value)
        {
            Console.WriteLine("Backup Created Successfully");
        }
        else
        {
            Console.WriteLine("No backup Created");
        }

    }
}