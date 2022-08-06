using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Migrations
{
    public partial class Update_060822 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anh",
                table: "ChiTietSP",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anh",
                table: "ChiTietSP");
        }
    }
}
