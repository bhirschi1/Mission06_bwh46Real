using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission06_bwh46.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    entryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lent = table.Column<string>(nullable: true),
                    notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.entryId);
                });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "entryId", "category", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 1, "Comedy", "Peter Segal", false, null, null, "PG-13", "Get Smart", 2008 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "entryId", "category", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 2, "Action", "Ryan Coogler", false, null, "There is a sequel, and a third movie soon!", "PG-13", "Creed", 2015 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "entryId", "category", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 3, "Romance/Comedy", "Glenn Ficarra, John Requa", false, null, null, "PG-13", "Crazy, Stupid, Love", 2011 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
