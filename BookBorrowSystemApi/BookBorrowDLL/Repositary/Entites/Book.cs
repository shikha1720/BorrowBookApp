using BookBorrowDLL.Repositary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowDLL.Repositary.Entitis

{
    public class Book : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int Rating { get; set; } = 0;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public bool IsBookAvailable { get; set; } = true;
        public string Description { get; set; } = string.Empty;
        public int LentByUserId { get; set; }
        public int CurrentlyBorrowedByUserId { get; set; } = 0;
    }
}
