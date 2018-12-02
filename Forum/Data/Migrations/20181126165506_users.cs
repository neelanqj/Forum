using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Categories_CategoryId",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "topics");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "posts");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_CategoryId",
                table: "topics",
                newName: "IX_topics_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_TopicId",
                table: "posts",
                newName: "IX_posts_TopicId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "topics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "topics",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "posts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviseDate",
                table: "posts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "posts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviseDate",
                table: "categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviseDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_topics",
                table: "topics",
                column: "TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_posts",
                table: "posts",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_topics_UserId1",
                table: "topics",
                column: "UserId1");

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
                name: "FK_posts_topics_TopicId",
                table: "posts",
                column: "TopicId",
                principalTable: "topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_AspNetUsers_UserId1",
                table: "posts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_topics_categories_CategoryId",
                table: "topics",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_topics_AspNetUsers_UserId1",
                table: "topics",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_AspNetUsers_UserId1",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_topics_TopicId",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_AspNetUsers_UserId1",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_topics_categories_CategoryId",
                table: "topics");

            migrationBuilder.DropForeignKey(
                name: "FK_topics_AspNetUsers_UserId1",
                table: "topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_topics",
                table: "topics");

            migrationBuilder.DropIndex(
                name: "IX_topics_UserId1",
                table: "topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_posts",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_UserId1",
                table: "posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_UserId1",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "topics");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "topics");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "ReviseDate",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "ReviseDate",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReviseDate",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "topics",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "posts",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_topics_CategoryId",
                table: "Topics",
                newName: "IX_Topics_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_TopicId",
                table: "Posts",
                newName: "IX_Posts_TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Categories_CategoryId",
                table: "Topics",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
