using BookBorrowDLL.Repositary.Entities;
using BookBorrowDLL.Repositary.Entitis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowDLL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBooks> BorrowedBooks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Shikha Jain",
                Username = "shikha",
                Password = "Shikha@123",
                TokenAvailable = 5,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Name = "Shreya Jain",
                Username = "shreya",
                Password = "Shreya@123",
                TokenAvailable = 5,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                Name = "Shreyansh Jain",
                Username = "shreyansh",
                Password = "Shreyansh@123",
                TokenAvailable = 5,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 4,
                Name = "Sonam Jain",
                Username = "sonam",
                Password = "Sonam@123",
                TokenAvailable = 0,
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                Name = "One Hundred Years Of Solitude",
                Author = "Gabriel Garcia",
                Genre = "Friction",
                Description = "One Hundred Years Of Solitude is a prime example of magic reakism. It was published in 1967. It is the history of the isolated town of Macondo and of the family who founds it, the Buendías. For years, the town has no contact with the outside world, except for gypsies who occasionally visit, peddling technologies like ice and telescopes.",
                Rating = 5,
                IsBookAvailable = true,
                LentByUserId = 1,
                CurrentlyBorrowedByUserId = 0
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 2,
                Name = "Nineteen Eighty-Four",
                Author = "George Orwell",
                Genre = "Novel",
                Description = "Nineteen Eighty-Four (also published as 1984) is a dystopian novel and cautionary tale by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.",
                Rating = 5,
                IsBookAvailable = true,
                LentByUserId = 2,
                CurrentlyBorrowedByUserId = 0
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 3,
                Name = "Where the Crawdads Sing",
                Author = "Delia Orwell",
                Genre = "Literature",
                Description = "Where the Crawdads Sing is a novel by Delia Owens that tells the story of Kya, a girl who grows up alone in the marshes of North Carolina after her family leaves her. The novel combines rich descriptions of the natural world with the story of Kya's coming-of-age and a murder mystery that unfolds in two timelines. The novel explores what people can get from nature, what they need from one another, and the conflict between these two ideas.",
                Rating = 5,
                IsBookAvailable = true,
                LentByUserId = 3,
                CurrentlyBorrowedByUserId = 0
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 4,
                Name = "Brave New World",
                Author = "Aldous Huxley",
                Genre = "Science-Friction",
                Description = "Brave New World is a dystopian novel by English author Aldous Huxley, written in 1931 and published in 1932. Largely set in a futuristic World State, whose citizens are environmentally engineered into an intelligence-based social hierarchy, the novel anticipates huge scientific advancements in reproductive technology, sleep-learning, psychological manipulation and classical conditioning that are combined to make a dystopian society which is challenged by the story's protagonist.",
                Rating = 5,
                IsBookAvailable = true,
                LentByUserId = 4,
                CurrentlyBorrowedByUserId = 0
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 5,
                Name = "The Woman in the Window ",
                Author = "A.J. Finn",
                Genre = "Thriller",
                Rating = 5,
                Description = "The Woman in the Window is a thriller novel by American author A.J. Finn, published by William Morrow on January 2, 2018. It hit #1 on the New York Times bestseller list.[1] The book follows the life of Dr. Anna Fox who suffers from agoraphobia and lives a reclusive life at her large home in New York City, where she one day witnesses a murder across the street.",
                IsBookAvailable = true,
                LentByUserId = 1,
                CurrentlyBorrowedByUserId = 0
            });
        }
    }
}
