using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class removefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Post",
                table: "Posts",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Post",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Posts",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
