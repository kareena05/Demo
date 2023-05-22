using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.Migrations
{
    /// <inheritdoc />
    public partial class like_tbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "like_Tweet",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tweet_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_like_Tweet", x => x.id);
                    table.ForeignKey(
                        name: "FK_like_Tweet_Tweets_tweet_id",
                        column: x => x.tweet_id,
                        principalTable: "Tweets",
                        principalColumn: "Id" );
                    table.ForeignKey(
                        name: "FK_like_Tweet_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_like_Tweet_tweet_id",
                table: "like_Tweet",
                column: "tweet_id");

            migrationBuilder.CreateIndex(
                name: "IX_like_Tweet_user_id",
                table: "like_Tweet",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "like_Tweet");
        }
    }
}
