using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApiBook.DataAccessLayer.Migrations
{
    public partial class add_author_quatation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Quotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_AuthorID",
                table: "Quotations",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Authors_AuthorID",
                table: "Quotations",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Authors_AuthorID",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_AuthorID",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Quotations");
        }
    }
}
