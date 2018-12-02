using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class users_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_AspNetUsers_UserId1",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_AspNetUsers_UserId1",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_UserId1",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_categories_UserId1",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "categories");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "posts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "categories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_posts_UserId",
                table: "posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_UserId",
                table: "categories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_AspNetUsers_UserId",
                table: "categories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_AspNetUsers_UserId",
                table: "posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_AspNetUsers_UserId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_AspNetUsers_UserId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_UserId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_categories_UserId",
                table: "categories");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "posts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "posts",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "categories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_posts_UserId1",
                table: "posts",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_categories_UserId1",
                table: "categories",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_AspNetUsers_UserId1",
                table: "categories",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_AspNetUsers_UserId1",
                table: "posts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
