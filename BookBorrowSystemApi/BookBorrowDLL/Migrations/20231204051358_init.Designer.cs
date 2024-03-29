﻿// <auto-generated />
using BookBorrowDLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookBorrowDLL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231204051358_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookBorrowDLL.Repositary.Entities.BorrowedBooks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("BorrowedOn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<string>("ReturnedOn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BorrowedBooks");
                });

            modelBuilder.Entity("BookBorrowDLL.Repositary.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TokenAvailable")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Shikha Jain",
                            Password = "Shikha@123",
                            TokenAvailable = 5,
                            Username = "shikha"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shreya Jain",
                            Password = "Shreya@123",
                            TokenAvailable = 5,
                            Username = "shreya"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Shreyansh Jain",
                            Password = "Shreyansh@123",
                            TokenAvailable = 5,
                            Username = "shreyansh"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sonam Jain",
                            Password = "Sonam@123",
                            TokenAvailable = 0,
                            Username = "sonam"
                        });
                });

            modelBuilder.Entity("BookBorrowDLL.Repositary.Entitis.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentlyBorrowedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBookAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("LentByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Gabriel Garcia",
                            CurrentlyBorrowedByUserId = 0,
                            Description = "One Hundred Years Of Solitude is a prime example of magic reakism. It was published in 1967. It is the history of the isolated town of Macondo and of the family who founds it, the Buendías. For years, the town has no contact with the outside world, except for gypsies who occasionally visit, peddling technologies like ice and telescopes.",
                            Genre = "Friction",
                            IsBookAvailable = true,
                            LentByUserId = 1,
                            Name = "One Hundred Years Of Solitude",
                            Rating = 5
                        },
                        new
                        {
                            Id = 2,
                            Author = "George Orwell",
                            CurrentlyBorrowedByUserId = 0,
                            Description = "Nineteen Eighty-Four (also published as 1984) is a dystopian novel and cautionary tale by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.",
                            Genre = "Novel",
                            IsBookAvailable = true,
                            LentByUserId = 2,
                            Name = "Nineteen Eighty-Four",
                            Rating = 5
                        },
                        new
                        {
                            Id = 3,
                            Author = "Delia Orwell",
                            CurrentlyBorrowedByUserId = 0,
                            Description = "Where the Crawdads Sing is a novel by Delia Owens that tells the story of Kya, a girl who grows up alone in the marshes of North Carolina after her family leaves her. The novel combines rich descriptions of the natural world with the story of Kya's coming-of-age and a murder mystery that unfolds in two timelines. The novel explores what people can get from nature, what they need from one another, and the conflict between these two ideas.",
                            Genre = "Literature",
                            IsBookAvailable = true,
                            LentByUserId = 3,
                            Name = "Where the Crawdads Sing",
                            Rating = 5
                        },
                        new
                        {
                            Id = 4,
                            Author = "Aldous Huxley",
                            CurrentlyBorrowedByUserId = 0,
                            Description = "Brave New World is a dystopian novel by English author Aldous Huxley, written in 1931 and published in 1932. Largely set in a futuristic World State, whose citizens are environmentally engineered into an intelligence-based social hierarchy, the novel anticipates huge scientific advancements in reproductive technology, sleep-learning, psychological manipulation and classical conditioning that are combined to make a dystopian society which is challenged by the story's protagonist.",
                            Genre = "Science-Friction",
                            IsBookAvailable = true,
                            LentByUserId = 4,
                            Name = "Brave New World",
                            Rating = 5
                        },
                        new
                        {
                            Id = 5,
                            Author = "A.J. Finn",
                            CurrentlyBorrowedByUserId = 0,
                            Description = "The Woman in the Window is a thriller novel by American author A.J. Finn, published by William Morrow on January 2, 2018. It hit #1 on the New York Times bestseller list.[1] The book follows the life of Dr. Anna Fox who suffers from agoraphobia and lives a reclusive life at her large home in New York City, where she one day witnesses a murder across the street.",
                            Genre = "Thriller",
                            IsBookAvailable = true,
                            LentByUserId = 1,
                            Name = "The Woman in the Window ",
                            Rating = 5
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
