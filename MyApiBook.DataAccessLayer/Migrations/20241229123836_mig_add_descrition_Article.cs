using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApiBook.DataAccessLayer.Migrations
{
    public partial class mig_add_descrition_Article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Article",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Article");
        }
    }
}
