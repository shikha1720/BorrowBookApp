using BookBorrowDLL.Repositary.Entitis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowDLL
{
    public class BookDLL
    {
        private readonly AppDbContext _DB;

        public BookDLL(AppDbContext dLL)
        {
            _DB = dLL;
        }

        public bool AddNewBook(int userId, Book book)
        {
            var added = false;
            var user  = _DB.Users.FirstOrDefault(user => user.Id == userId);
            if (user != null)
            {
                user.TokenAvailable += 1;
            }
            if (book != null)
            {
                _DB.Books.Add(book);
                added = true;
            }
            _DB.SaveChanges();

            return added;
        }
        public IList<Book> GetAllBooks()
        {
            var books = _DB.Books.ToList();
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = _DB.Books.FirstOrDefault(x => x.Id == id);
            return book;
        }

        public IList<Book> GetLentBooks(int userId)
        {
            var books = _DB.Books
                .Where(book => book.LentByUserId == userId)
                .ToList();

            return books;
        }

        public bool ReturnBook(int userId, int bookId)
        {
            var returned = false;
            var book = _DB.Books.FirstOrDefault(book => book.Id == bookId && book.CurrentlyBorrowedByUserId == userId);
            if (book != null && !book.IsBookAvailable)
            {
                book.IsBookAvailable = true;
                book.CurrentlyBorrowedByUserId = 0;
                _DB.SaveChanges();

                returned = true;
            }

            var bBook = _DB.BorrowedBooks.FirstOrDefault(book => book.BookId == bookId && book.UserId == userId);
            if (bBook != null)
            {
                bBook.IsReturned = true;
                bBook.ReturnedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            _DB.SaveChanges();
            return returned;
        }
    }
}
