﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace YummyCookbook.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    Difficulty = table.Column<string>(nullable: true),
                    NoLikes = table.Column<int>(nullable: false),
                    Ingredients = table.Column<string>(nullable: true),
                    Process = table.Column<string>(nullable: true),
                    TipsAndTricks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
