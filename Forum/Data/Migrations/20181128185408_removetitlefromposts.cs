using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class removetitlefromposts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_topics_AspNetUsers_UserId1",
                table: "topics");

            migrationBuilder.DropIndex(
                name: "IX_topics_UserId1",
                table: "topics");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "topics");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "posts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "topics",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_topics_UserId",
                table: "topics",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_topics_AspNetUsers_UserId",
                table: "topics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_topics_AspNetUsers_UserId",
                table: "topics");

            migrationBuilder.DropIndex(
                name: "IX_topics_UserId",
                table: "topics");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "topics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "topics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_topics_UserId1",
                table: "topics",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_topics_AspNetUsers_UserId1",
                table: "topics",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
