using BookBorrowBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBorrowSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BookBorrowBLL.UserBLL _BLL;
        public UserController(UserBLL bll)
        {
            _BLL = bll;
        }

        [HttpGet("Login")]
        public IActionResult Login(string username, string password)
        {
            if(username == null || password == null)
            {
                return BadRequest();
            }
            return Ok(_BLL.Login(username, password));
        }

        [HttpGet("Tokens/{userId}")]
        public IActionResult GetTokens(int userId)
        {
            if (userId == 0)
            {
                return BadRequest();
            }
            var result = _BLL.GetTokens(userId);
            return Ok(result);
        }
    }
}
