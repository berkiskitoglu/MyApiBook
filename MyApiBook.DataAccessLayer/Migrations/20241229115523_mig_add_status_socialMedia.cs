using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApiBook.DataAccessLayer.Migrations
{
    public partial class mig_add_status_socialMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "SocialMedias",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SocialMedias");
        }
    }
}
