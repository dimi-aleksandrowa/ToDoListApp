using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoListCategories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoListCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ToDoListStatuses",
                columns: table => new
                {
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoListStatuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.ListId);
                    table.ForeignKey(
                        name: "FK_ToDoLists_ToDoListCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ToDoListCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoLists_ToDoListStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ToDoListStatuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ToDoListCategories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { "work", "Work" },
                    { "home", "Home" },
                    { "ex", "Excercise" },
                    { "shop", "Shopping" },
                    { "call", "Contact" }
                });

            migrationBuilder.InsertData(
                table: "ToDoListStatuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { "open", "Open" },
                    { "done", "Completed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_CategoryId",
                table: "ToDoLists",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_StatusId",
                table: "ToDoLists",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoLists");

            migrationBuilder.DropTable(
                name: "ToDoListCategories");

            migrationBuilder.DropTable(
                name: "ToDoListStatuses");
        }
    }
}
