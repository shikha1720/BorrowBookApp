using BookBorrowBLL;
using BookBorrowDLL.Repositary.Entitis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookBorrowBLL.BookBLL _BLL;
        public BookController(BookBLL bll)
        {
            _BLL = bll;
        }

        [HttpPost("NewBook/{userId}")]
        public IActionResult AddNewBook(int userId, Book book)
        { 
            if(book == null)
            {
                return BadRequest();
            }
            return Ok(_BLL.AddNewBook(userId, book) ? "success" : "not added");
        }

        [HttpGet("GetAllBooks")] 
        public IActionResult GetAllBooks()
        {
            var books = _BLL.GetAllBooks();
            if(books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("GetBookById/{id}")]
        public IActionResult GetBookById(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var book = _BLL.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("GetLentBooks/{id}")]

        public IActionResult GetLentBooks(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok(_BLL.GetLentBooks(id));
        }

        [HttpGet("ReturnBook/{userId}/{bookId}")]
        public IActionResult ReturnBook(int userId, int bookId)
        {
            if (userId == 0 || bookId == 0)
            {
                return BadRequest();
            }
            var result = _BLL.ReturnBook(userId, bookId) ? "success" : "not returned";
            return Ok(result);
        }

    }
}
