namespace BookManagementSystem;

class Book
{   

    public int Id
    {
        set;
        get;
    }

    public string? Title
    {
        set;
        get;
    }

    public string? Author
    {
        set;
        get;
    }

    public double Price
    {
        set;
        get;
    }

    public Book(){}

    public Book(int book_id, string? book_title, string? book_author, double book_price)
    {
        Id = book_id;
        Title = book_title;
        Author = book_author;
        Price = book_price;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id}, Title: {Title}, Author: {Author}, Price: {Price}");
    }
}