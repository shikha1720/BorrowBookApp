using BookBorrowDLL.Repositary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowDLL
{
    public class BookBorrowDLL
    {
        private readonly AppDbContext _DB;

        public BookBorrowDLL(AppDbContext dLL)
        {
            _DB = dLL;
        }

        public bool BorrowBook(int userId, int bookId)
        {
            var borrowed = false;
            var user = _DB.Users.FirstOrDefault(u => u.Id == userId);
            var book = _DB.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && user != null && book.IsBookAvailable && user.TokenAvailable > 0)
            {
                book.IsBookAvailable = false;
                book.CurrentlyBorrowedByUserId = userId;
                user.TokenAvailable -= 1;
                var lentUser = _DB.Users.FirstOrDefault(u => u.Id == book.LentByUserId);
                if (lentUser != null)
                {
                    lentUser.TokenAvailable += 1;
                }
                _DB.SaveChanges();
                borrowed = true;
            }

            var borrowedBook = new BorrowedBooks
            {
                UserId = userId,
                BookId = bookId,
                IsReturned = false,
                BorrowedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ReturnedOn = string.Empty
            };

            _DB.BorrowedBooks.Add(borrowedBook);
            _DB.SaveChanges();

            return borrowed;
        }

        public IList<object> GetBorrowedBooks(int userId)
        {
            var myBorrowedBooks = (
                from borrowedBook in _DB.BorrowedBooks
                where borrowedBook.UserId == userId
                join book in _DB.Books on borrowedBook.BookId equals book.Id
                select new
                {
                    BookId = book.Id,
                    BookName = book.Name,
                    Author = book.Author,
                    Genre = book.Genre,
                    IsReturned = borrowedBook.IsReturned,
                    BorrowedOn = borrowedBook.BorrowedOn,
                    ReturnedOn = borrowedBook.ReturnedOn

                }).ToList();

            return myBorrowedBooks.Cast<object>().ToList();
        }
    }
}
