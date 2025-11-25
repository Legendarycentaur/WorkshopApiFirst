using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookLibraryApi.Models;
using BookLibraryApi.Models.DTOs;

namespace BookLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Books : ControllerBase
    {
        private static List<Book> _books = new()
        {
            new Book(_ISBN : "978-0132350884", _title:"Clean Code", _author : "Robert Martin",
                       _year : 2008),
            new Book(_ISBN : "978-0201633612", _title:"Design Patterns", _author : "Gang of Four",
                       _year : 1994),
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(_books);
        }
        [Route("{_isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> GetBook(string _isbn)
        {
            var book = _books.FirstOrDefault(b => b.ISBN == _isbn);


            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Book> CreateBook([FromBody] CreateBookDTO bookDto)
        {
        

            var book = new Book(_title: bookDto.Title, _author: bookDto.Author, _ISBN: bookDto.ISBN, _year: bookDto.Year);

            _books.Add(book);

            return CreatedAtAction(nameof(GetBook), new
            {
                _isbn = book.ISBN
            }, book);
        }


        /// <summary>
        /// Uppdatera en befintlig bok
        /// </summary>
        [HttpPatch("{_isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> UpdateBook(string _isbn, [FromBody] UpdateBookDto updateDto)
        {
            var book = _books.FirstOrDefault(b => b.ISBN == _isbn);


            // Uppdatera endast angivna fält
            if (updateDto.Title != null) book.Title = updateDto.Title;
            if (updateDto.Author != null) book.Author = updateDto.Author;
            // if (updateDto.ISBN != null) book.ISBN = updateDto.ISBN;
            if (updateDto.Year.HasValue) book.Year = updateDto.Year.Value;
            // if (updateDto.IsAvailable.HasValue) book.IsAvailable = updateDto.IsAvailable.Value;

            return Ok(book);
        }

        /// <summary>
        /// Ta bort en bok
        /// </summary>
        [HttpDelete("{_isbn}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBook(string _isbn)
        {
            var book = _books.FirstOrDefault(b => b.ISBN == _isbn);


            _books.Remove(book);
            return NoContent();
        }


    }
}
