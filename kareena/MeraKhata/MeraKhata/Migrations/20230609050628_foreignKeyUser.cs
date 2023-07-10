using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeraKhata.Migrations
{
    public partial class foreignKeyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Backup",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Backup",
                newName: "id");
        }
    }
}
