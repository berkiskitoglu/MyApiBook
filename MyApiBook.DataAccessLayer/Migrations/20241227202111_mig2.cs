using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApiBook.DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookPrice",
                table: "Books",
                newName: "OrginalPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentPrice",
                table: "Books",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "OrginalPrice",
                table: "Books",
                newName: "BookPrice");
        }
    }
}
