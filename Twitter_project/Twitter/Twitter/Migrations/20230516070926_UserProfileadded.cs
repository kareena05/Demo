using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.Migrations
{
    /// <inheritdoc />
    public partial class UserProfileadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_profile_img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    account_type = table.Column<bool>(type: "bit", nullable: false,defaultValue:true),
                    is_active = table.Column<bool>(type: "bit", nullable: false,defaultValue:true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    User_id_idid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_Users_User_id_idid",
                        column: x => x.User_id_idid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_User_id_idid",
                table: "UserProfile",
                column: "User_id_idid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfile");
        }
    }
}
