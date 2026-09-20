namespace BookManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book(1,"C#","Welbert",1200);
        book1.DisplayInfo();

        Book book2 = new Book();
        book2.Id = 2;
        book2.Title = "C#2";
        book2.Author = "Welbert02";
        book2.Price = 1300;

        book2.DisplayInfo();
    }
}