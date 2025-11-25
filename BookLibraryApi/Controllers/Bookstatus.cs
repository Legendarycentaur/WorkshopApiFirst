using BookLibraryApi.Models;
using BookLibraryApi.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bookstatuses : ControllerBase
    {
        private static List<BookStatus> _bookstatuses = new()
        {
            new BookStatus(_bookstatusId:"231609as8d7212io", _ISBN : "978-0132350884", _status:false),
            new BookStatus(_bookstatusId:"123659735asgda2", _ISBN : "978-0201633612", _status:true),
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<BookStatus>> GetBooks()
        {
            return Ok(_bookstatuses);
        }
        [Route("{_bookstatusId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookStatus> GetBookStatus(string _bookstatusId)
        {
            var book = _bookstatuses.FirstOrDefault(b => b.BookstatusId == _bookstatusId);

            if (book == null)
            {
                return NotFound(new { message = $"Bok med BookstatusId {_bookstatusId} hittades inte" });
            }

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Book> CreateBookStatus([FromBody] CreateBookStatusDTO bookstatusDto)
        {
            var bookstatus = new BookStatus(_status: bookstatusDto.Status, _ISBN: bookstatusDto.ISBN, _bookstatusId: Guid.NewGuid().ToString());

            _bookstatuses.Add(bookstatus);

            return CreatedAtAction(nameof(GetBookStatus), new
            {
                _bookstatusId = bookstatus.BookstatusId
            }, bookstatus);
        }


        /// <summary>
        /// Uppdatera en befintlig bok
        /// </summary>
        [HttpPatch("{_bookstatusId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookStatus> UpdateBookStatus(string _bookstatusId, [FromBody] UpdateBookStatusDTO updateDto)
        {
            var bookstatus = _bookstatuses.FirstOrDefault(b => b.BookstatusId == _bookstatusId);

            if (bookstatus == null)
            {
                return NotFound(new { message = $"Status med BookstatusId {_bookstatusId} hittades inte" });
            }

            // Uppdatera endast angivna fält
            if (updateDto.ISBN != null) bookstatus.ISBN = updateDto.ISBN;
            if (updateDto.Status != null) bookstatus.Status = (bool)updateDto.Status;
            return Ok(bookstatus);
        }

        /// <summary>
        /// Ta bort en bokstatus
        /// </summary>
        [HttpDelete("{_bookstatusId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBook(string _bookstatusId)
        {
            var bookstatus = _bookstatuses.FirstOrDefault(b => b.BookstatusId == _bookstatusId);

            if (bookstatus == null)
            {
                return NotFound(new { message = $"Bok medbookstatus id {_bookstatusId} hittades inte" });
            }

            _bookstatuses.Remove(bookstatus);
            return NoContent();
        }
    }
}
