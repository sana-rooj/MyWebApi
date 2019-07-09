using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace customerService.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    SerialNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order_Idd = table.Column<int>(nullable: false),
                    Total_Items = table.Column<int>(nullable: false),
                    Total_Price = table.Column<float>(nullable: false),
                    Total_Tax = table.Column<float>(nullable: false),
                    Total_Sum_Tax = table.Column<float>(nullable: false),
                    Order_Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.SerialNo);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Product_Name = table.Column<string>(nullable: true),
                    Product_Des = table.Column<string>(nullable: true),
                    Product_Price = table.Column<float>(nullable: false),
                    Product_Tax = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders_Products",
                columns: table => new
                {
                    SerialNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order_Id = table.Column<int>(nullable: false),
                    Product_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_Products", x => x.SerialNo);
                    table.ForeignKey(
                        name: "FK_Orders_Products_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "SerialNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_Id", "Product_Des", "Product_Name", "Product_Price", "Product_Tax" },
                values: new object[,]
                {
                    { 1, "white sause", "Pasta", 880f, 50f },
                    { 2, "grilled", "Chicken", 880f, 50f },
                    { 3, "labaniese sause", "Burger", 880f, 50f },
                    { 4, "chicken maushroom sause", "stake", 880f, 50f },
                    { 5, "BBQ", "pizza", 880f, 50f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Products_Order_Id",
                table: "Orders_Products",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Products_Product_Id",
                table: "Orders_Products",
                column: "Product_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders_Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
