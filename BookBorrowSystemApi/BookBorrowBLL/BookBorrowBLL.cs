using BookBorrowDLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowBLL
{
    public class BookBorrowBLL
    {
        private readonly BookBorrowDLL.BookBorrowDLL _DLL;
        public BookBorrowBLL(BookBorrowDLL.BookBorrowDLL dll)
        {
            _DLL = dll;
        }

        public bool BorrowBook(int userId, int bookId)
        {
            var result = _DLL.BorrowBook(userId, bookId);
            return result;
        }

        public IList<object> GetBorrowedBooks(int id)
        {
            return _DLL.GetBorrowedBooks(id);
        }
    }
}
