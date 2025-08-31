using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kcg.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TOPMenu",
                columns: table => new
                {
                    TOPMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Orders = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOPMenu", x => x.TOPMenuId);
                });

            migrationBuilder.InsertData(
                table: "TOPMenu",
                columns: new[] { "TOPMenuId", "Icon", "Name", "Orders", "Url" },
                values: new object[,]
                {
                    { new Guid("29055c4d-31ff-43e0-9d1c-1a677d57889c"), "Icon5", "市長信箱", 5, "a5" },
                    { new Guid("3f7e8247-0fa8-495a-86d9-a117a224fc7e"), "Icon4", "雙語詞彙", 4, "a4" },
                    { new Guid("8b2bc6ff-a62d-4799-86fe-9c04b2496a9e"), "Icon1", "網站導覽", 1, "a1" },
                    { new Guid("92ca1aa4-706c-4ce3-a250-7e720f5e7239"), "Icon2", "回首頁", 2, "a2" },
                    { new Guid("afbe912a-bf31-4e9a-af47-0035bb30bbbd"), "Icon3", "English", 3, "a3" },
                    { new Guid("c1e1cadf-48bf-4fb6-b1aa-5a4d9d92a81d"), "Icon6", "洽公導覽", 6, "a6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TOPMenu");
        }
    }
}
