namespace BookManagementSystem;

class BookDataAccess
{
    public bool add_book(Book book)
    {
        FileStream fs = new FileStream("books.txt", FileMode.Append);
        StreamWriter writer = new StreamWriter(fs);
        string line = $"{book.Id}, {book.Title}, {book.Author}, {book.Price}";

        writer.WriteLine(line);
        writer.Close();
        fs.Close();

        return true;
    }

    public List<Book> view_all_books()

    {
        List<Book> books = new List<Book>();

        if (!File.Exists("books.txt"))
        {
            return books;
        }


        FileStream fs = new FileStream("books.txt", FileMode.Open);

        StreamReader reader = new StreamReader(fs);

        string? line = reader.ReadLine();


        while (line != null)
        {
            string[] parts = line.Split(",");
            Book b1 = new Book();
            b1.Id = int.Parse(parts[0]);
            b1.Title = parts[1].Trim();
            b1.Author = parts[2].Trim();
            b1.Price = Double.Parse(parts[3].Trim());

            books.Add(b1);

            line = reader.ReadLine();
        }

        reader.Close();
        fs.Close();
        return books;
    }

    public Dictionary<int, Book> get_book_dictionary()
    {
        List<Book> books = view_all_books();

        Dictionary<int, Book> dict = new Dictionary<int, Book>();

        foreach (Book book in books)
        {
            if (!dict.ContainsKey(book.Id))
            {
                dict.Add(book.Id, book);
            }
        }

        return dict;
    }

    public Book? find_book_by_id(int id)
    {
        Dictionary<int, Book> dict = get_book_dictionary();

        if (dict.ContainsKey(id))
        {
            return dict[id];
        }

        return null;

    }


    public bool CreateBackup()
    {
       if (!File.Exists("books.txt"))
        {
            return false;
        }

        FileStream fs = new FileStream("books.txt", FileMode.Open);
        FileStream backup = new FileStream("books_backup.txt", FileMode.Create);

        int data = fs.ReadByte();

        while (data != -1)
        {
            backup.WriteByte((byte)data);
            data = fs.ReadByte();
        }

        fs.Close();
        backup.Close();

        return true;
    }
}   