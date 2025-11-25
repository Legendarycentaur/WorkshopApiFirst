using System;

namespace BookLibraryApi.Models;

public class BookStatus
{
    public string BookstatusId { get; set; }
    public string ISBN { get; set; }
    public bool Status { get; set; }

    public BookStatus(string _bookstatusId = "", string _ISBN = "", bool _status = false)
    {
        ISBN = _ISBN;
        Status = _status;
        BookstatusId = _bookstatusId;
    }
}
