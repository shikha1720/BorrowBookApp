using BookBorrowDLL.Repositary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowDLL
{
    public class UserDLL
    {
        private readonly AppDbContext _DB;

        public UserDLL(AppDbContext dLL)
        {
            _DB = dLL;
        }

        public bool AuthenticateUser(string username, string password, out User? user)
        {
            var temp = false;
            var result = _DB.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (result != null)
            {
                user = result;
                temp = true;
            }
            else
            {
                user = null;
            }
            return temp;
        }

        public int GetToken(int userId)
        {
            var token = 0;
            var user = _DB.Users.FirstOrDefault(user => user.Id == userId);
            if (user != null)
            {
                token = user.TokenAvailable;
            }
            return token;
        }
    }
}
