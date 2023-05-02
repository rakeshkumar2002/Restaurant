using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CategoryDescription = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    DishID = table.Column<int>(type: "int", nullable: false),
                    DishName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DishDescription = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DishPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DishImage = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Nature = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.DishID);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    MenuName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MenuDescription = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    MenuImage = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuID);
                });

            migrationBuilder.CreateTable(
                name: "Category_Dish",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    DishID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Dish", x => new { x.CategoryID, x.DishID });
                    table.ForeignKey(
                        name: "FK__Category___Categ__656C112C",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK__Category___DishI__66603565",
                        column: x => x.DishID,
                        principalTable: "Dish",
                        principalColumn: "DishID");
                });

            migrationBuilder.CreateTable(
                name: "Menu_Category",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    MenuId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Category", x => new { x.MenuID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK__Menu_Cate__Categ__5EBF139D",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK__Menu_Cate__MenuI__5DCAEF64",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "MenuID");
                    table.ForeignKey(
                        name: "FK_Menu_Category_Menu_MenuId1",
                        column: x => x.MenuId1,
                        principalTable: "Menu",
                        principalColumn: "MenuID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Dish_DishID",
                table: "Category_Dish",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Category_CategoryID",
                table: "Menu_Category",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Category_MenuId1",
                table: "Menu_Category",
                column: "MenuId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category_Dish");

            migrationBuilder.DropTable(
                name: "Menu_Category");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
