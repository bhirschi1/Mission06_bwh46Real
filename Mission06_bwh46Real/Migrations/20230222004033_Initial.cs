using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission06_bwh46Real.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    catName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    entryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lent = table.Column<string>(nullable: true),
                    notes = table.Column<string>(maxLength: 25, nullable: true),
                    categoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.entryId);
                    table.ForeignKey(
                        name: "FK_Entries_Category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "categoryId", "catName" },
                values: new object[] { 1, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "categoryId", "catName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "categoryId", "catName" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "categoryId", "catName" },
                values: new object[] { 4, "Family" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "categoryId", "catName" },
                values: new object[] { 5, "Horror/Suspense" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "categoryId", "catName" },
                values: new object[] { 6, "Miscellaneous" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "categoryId", "catName" },
                values: new object[] { 7, "Television" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "categoryId", "catName" },
                values: new object[] { 8, "VHS" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "entryId", "categoryId", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 1, 2, "Peter Segal", false, null, null, "PG-13", "Get Smart", 2008 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "entryId", "categoryId", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 3, 2, "Glenn Ficarra, John Requa", false, null, null, "PG-13", "Crazy, Stupid, Love", 2011 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "entryId", "categoryId", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 2, 3, "Ryan Coogler", false, null, "There is a sequel, and a third movie soon!", "PG-13", "Creed", 2015 });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_categoryId",
                table: "Entries",
                column: "categoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
