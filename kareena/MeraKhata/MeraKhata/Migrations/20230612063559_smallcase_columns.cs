using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeraKhata.Migrations
{
    public partial class smallcase_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_backup_users_Userid",
                table: "backup");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "users",
                newName: "mobile");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "users",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_users_Email",
                table: "users",
                newName: "IX_users_email");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "backup",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "Lastbackup",
                table: "backup",
                newName: "lastbackup");

            migrationBuilder.RenameColumn(
                name: "Filename",
                table: "backup",
                newName: "filename");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "backup",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_backup_Userid",
                table: "backup",
                newName: "IX_backup_userid");

            migrationBuilder.AddForeignKey(
                name: "FK_backup_users_userid",
                table: "backup",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_backup_users_userid",
                table: "backup");

            migrationBuilder.RenameColumn(
                name: "mobile",
                table: "users",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "users",
                newName: "Fullname");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_users_email",
                table: "users",
                newName: "IX_users_Email");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "backup",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "lastbackup",
                table: "backup",
                newName: "Lastbackup");

            migrationBuilder.RenameColumn(
                name: "filename",
                table: "backup",
                newName: "Filename");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "backup",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_backup_userid",
                table: "backup",
                newName: "IX_backup_Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_backup_users_Userid",
                table: "backup",
                column: "Userid",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
