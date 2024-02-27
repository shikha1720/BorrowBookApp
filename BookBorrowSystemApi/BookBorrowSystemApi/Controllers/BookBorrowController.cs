using BookBorrowBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookBorrowController : ControllerBase
    {
        private readonly BookBorrowBLL.BookBorrowBLL _BLL;
        public BookBorrowController(BookBorrowBLL.BookBorrowBLL bll)
        {
            _BLL = bll;
        }

        [HttpGet("{userId}/{bookId}")]
        public IActionResult BorrowBook(int userId, int bookId)
        {
            if (userId == 0 || bookId == 0)
            {
                return NotFound();
            }
            var result = _BLL.BorrowBook(userId, bookId) ? "success" : "fail";
            return Ok(result);
        }

        [HttpGet("GetBorrowedBooks/{id}")]
        public IActionResult GetBorrowedBooks(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            return Ok(_BLL.GetBorrowedBooks(id));
        }
    }
}
