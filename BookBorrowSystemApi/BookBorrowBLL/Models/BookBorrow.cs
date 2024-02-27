using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowBLL.Models
{
    public class BorrowedBooks : BaseModel
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool IsReturned { get; set; } = false;
        public string BorrowedOn { get; set; } = string.Empty;
        public string ReturnedOn { get; set; } = string.Empty;

    }
}
