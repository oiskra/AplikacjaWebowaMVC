using Microsoft.EntityFrameworkCore.Migrations;

namespace AplikacjaWebowaMVC.Migrations
{
    public partial class prywatneDaneStudenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdresZamieszkania",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdresZamieszkania",
                table: "Student");
        }
    }
}
