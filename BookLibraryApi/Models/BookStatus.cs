using System;

namespace BookLibraryApi.Models;

public class BookStatus
{
    public string ISBN { get; set; }
    public bool Status { get; set; }

    public BookStatus(string _ISBN = "", bool _status = false)
    {
        ISBN = _ISBN;
        Status = _status;
    }
}
