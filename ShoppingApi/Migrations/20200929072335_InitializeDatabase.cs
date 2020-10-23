using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApi.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Price = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Items_Id",
                        column: x => x.Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kendaraan" },
                    { 2, "makanan" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[,]
                {
                    { 1, 30, "Maria" },
                    { 2, 20, "Mahmud" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Beat", 12000000 },
                    { 2, 1, "N-Max", 32000000 },
                    { 3, 2, "Sarimie", 1200 },
                    { 4, 2, "AQUA", 3500 }
                });

            migrationBuilder.InsertData(
                table: "CustomerItems",
                columns: new[] { "Id", "CustomerId", "ItemId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 4, 2, 1 },
                    { 5, 2, 2 },
                    { 2, 1, 3 },
                    { 3, 1, 4 },
                    { 6, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "Description", "Weight" },
                values: new object[,]
                {
                    { 1, "Second", 20 },
                    { 2, "Baru", 30 },
                    { 3, "1 Dus", 3 },
                    { 4, "1 Dus", 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerItems_CustomerId",
                table: "CustomerItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerItems_ItemId",
                table: "CustomerItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerItems");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
