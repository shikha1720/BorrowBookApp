using BookBorrowDLL;
using BookBorrowDLL.Repositary.Entitis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowBLL
{
    public class BookBLL
    {
        private readonly BookBorrowDLL.BookDLL _DLL;
        public BookBLL(BookDLL dll)
        {
            _DLL = dll;
        }
        public bool AddNewBook(int userId, Book book)
        {
            book.Name = book.Name.Trim();
            book.Author = book.Author.Trim();
            book.Genre = book.Genre.Trim();
            book.Description = book.Description.Trim();
            book.LentByUserId = book.LentByUserId;

            var result = _DLL.AddNewBook(userId, book);
            return result;
        }

        public IList<Book> GetAllBooks()
        {
            var books = _DLL.GetAllBooks();
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = _DLL.GetBookById(id);
            return book;
        }

        public IList<Book> GetLentBooks(int id)
        {
            return _DLL.GetLentBooks(id);
        }

        public bool ReturnBook(int userId, int bookId)
        {
            var result = _DLL.ReturnBook(userId, bookId);
            return result;
        }
    }
}
