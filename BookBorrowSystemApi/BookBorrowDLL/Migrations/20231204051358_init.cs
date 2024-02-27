using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookBorrowDLL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBookAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LentByUserId = table.Column<int>(type: "int", nullable: false),
                    CurrentlyBorrowedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false),
                    BorrowedOn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnedOn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CurrentlyBorrowedByUserId", "Description", "Genre", "IsBookAvailable", "LentByUserId", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "Gabriel Garcia", 0, "One Hundred Years Of Solitude is a prime example of magic reakism. It was published in 1967. It is the history of the isolated town of Macondo and of the family who founds it, the Buendías. For years, the town has no contact with the outside world, except for gypsies who occasionally visit, peddling technologies like ice and telescopes.", "Friction", true, 1, "One Hundred Years Of Solitude", 5 },
                    { 2, "George Orwell", 0, "Nineteen Eighty-Four (also published as 1984) is a dystopian novel and cautionary tale by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.", "Novel", true, 2, "Nineteen Eighty-Four", 5 },
                    { 3, "Delia Orwell", 0, "Where the Crawdads Sing is a novel by Delia Owens that tells the story of Kya, a girl who grows up alone in the marshes of North Carolina after her family leaves her. The novel combines rich descriptions of the natural world with the story of Kya's coming-of-age and a murder mystery that unfolds in two timelines. The novel explores what people can get from nature, what they need from one another, and the conflict between these two ideas.", "Literature", true, 3, "Where the Crawdads Sing", 5 },
                    { 4, "Aldous Huxley", 0, "Brave New World is a dystopian novel by English author Aldous Huxley, written in 1931 and published in 1932. Largely set in a futuristic World State, whose citizens are environmentally engineered into an intelligence-based social hierarchy, the novel anticipates huge scientific advancements in reproductive technology, sleep-learning, psychological manipulation and classical conditioning that are combined to make a dystopian society which is challenged by the story's protagonist.", "Science-Friction", true, 4, "Brave New World", 5 },
                    { 5, "A.J. Finn", 0, "The Woman in the Window is a thriller novel by American author A.J. Finn, published by William Morrow on January 2, 2018. It hit #1 on the New York Times bestseller list.[1] The book follows the life of Dr. Anna Fox who suffers from agoraphobia and lives a reclusive life at her large home in New York City, where she one day witnesses a murder across the street.", "Thriller", true, 1, "The Woman in the Window ", 5 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Name", "Password", "TokenAvailable", "Username" },
                values: new object[,]
                {
                    { 1, "Shikha Jain", "Shikha@123", 5, "shikha" },
                    { 2, "Shreya Jain", "Shreya@123", 5, "shreya" },
                    { 3, "Shreyansh Jain", "Shreyansh@123", 5, "shreyansh" },
                    { 4, "Sonam Jain", "Sonam@123", 0, "sonam" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BorrowedBooks");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
