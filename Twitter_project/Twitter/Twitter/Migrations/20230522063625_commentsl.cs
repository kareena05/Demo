using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.Migrations
{
    /// <inheritdoc />
    public partial class commentsl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_entity_Tweets_tweet_id",
                table: "Comment_entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_entity_Users_user_id",
                table: "Comment_entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment_entity",
                table: "Comment_entity");

            migrationBuilder.RenameTable(
                name: "Comment_entity",
                newName: "comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_entity_user_id",
                table: "comments",
                newName: "IX_comments_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_entity_tweet_id",
                table: "comments",
                newName: "IX_comments_tweet_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Tweets_tweet_id",
                table: "comments",
                column: "tweet_id",
                principalTable: "Tweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Users_user_id",
                table: "comments",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_Tweets_tweet_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_Users_user_id",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "Comment_entity");

            migrationBuilder.RenameIndex(
                name: "IX_comments_user_id",
                table: "Comment_entity",
                newName: "IX_Comment_entity_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_comments_tweet_id",
                table: "Comment_entity",
                newName: "IX_Comment_entity_tweet_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment_entity",
                table: "Comment_entity",
                column: "Id");

           
           
            migrationBuilder.AddForeignKey(
                name: "FK_Comment_entity_Tweets_tweet_id",
                table: "Comment_entity",
                column: "tweet_id",
                principalTable: "Tweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_entity_Users_user_id",
                table: "Comment_entity",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
