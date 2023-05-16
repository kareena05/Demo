using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.Migrations
{
    /// <inheritdoc />
    public partial class modified_active_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "UserProfile");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "UserProfile",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
