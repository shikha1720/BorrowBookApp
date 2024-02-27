using BookBorrowDLL;
using BookBorrowDLL.Repositary.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowBLL
{
    public class UserBLL
    {
        private readonly BookBorrowDLL.UserDLL _DLL;
        private readonly IConfiguration _configuration;
        public UserBLL(UserDLL dll, IConfiguration configuration = null)
        {
            _DLL = dll;
            _configuration = configuration;

        }

        public String Login(string username, string password)
        {
            if (_DLL.AuthenticateUser(username, password, out User? user))
            {
                if (user != null)
                {
                    var jwt = new Jwt(_configuration["Jwt:Key"], _configuration["Jwt:Duration"]);
                    var token = jwt.GenerateToken(user);
                    return token;
                }
            }
            return "Invalid";

        }

        public int GetTokens(int userId)
        {
            return _DLL.GetToken(userId);
        }
    }
}
