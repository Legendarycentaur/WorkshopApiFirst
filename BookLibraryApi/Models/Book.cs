using System;

namespace BookLibraryApi.Models;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int Year { get; set; }

    public Book(string _ISBN = "", string _title = "", string _author = "", int _year = 0)
    {
        ISBN = _ISBN;
        Title = _title;
        Author = _author;
        Year = _year;
    }
}
