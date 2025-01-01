using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApiBook.DataAccessLayer.Migrations
{
    public partial class mig_add_context_article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Authors_AuthorID",
                table: "Article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Article",
                table: "Article");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_Article_AuthorID",
                table: "Articles",
                newName: "IX_Articles_AuthorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "ArticleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Authors_AuthorID",
                table: "Articles",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Authors_AuthorID",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Article");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_AuthorID",
                table: "Article",
                newName: "IX_Article_AuthorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Article",
                table: "Article",
                column: "ArticleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Authors_AuthorID",
                table: "Article",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
