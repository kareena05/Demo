using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.Migrations
{
    /// <inheritdoc />
    public partial class UserProfile_foreign_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_Users_User_id_idid",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_User_id_idid",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "User_id_idid",
                table: "UserProfile");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_UserId",
                table: "UserProfile",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_Users_UserId",
                table: "UserProfile",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_Users_UserId",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_UserId",
                table: "UserProfile");

            migrationBuilder.AddColumn<int>(
                name: "User_id_idid",
                table: "UserProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_User_id_idid",
                table: "UserProfile",
                column: "User_id_idid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_Users_User_id_idid",
                table: "UserProfile",
                column: "User_id_idid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
