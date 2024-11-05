using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecureStore.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysToManufacture = table.Column<int>(type: "int", nullable: false),
                    StandardCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFilled = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Color", "DaysToManufacture", "Description", "ListPrice", "Name", "StandardCost", "Weight" },
                values: new object[,]
                {
                    { new Guid("ba9bb2d6-6f5f-4f13-82e8-78ab984970f7"), "Blue", 3, "Compact smartphone", 350m, "Smartphone", 200m, 0.3m },
                    { new Guid("e0661031-04ed-4bee-8a17-b6ae6bf79526"), "Black", 5, "Powerful laptop", 800m, "Laptop", 500m, 2.5m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("3bf3ffe2-5875-422b-ad54-506dc80c5fbd"), new DateTime(2024, 11, 3, 2, 49, 4, 256, DateTimeKind.Local).AddTicks(4234), "petr@example.com", "Petr", "Petrov", "password456", new DateTime(2024, 11, 3, 2, 49, 4, 256, DateTimeKind.Local).AddTicks(4234), "petrov" },
                    { new Guid("dcc76bfb-750d-4cad-843c-2df443074875"), new DateTime(2024, 11, 3, 2, 49, 4, 256, DateTimeKind.Local).AddTicks(4219), "ivan@example.com", "Ivan", "Ivanov", "password123", new DateTime(2024, 11, 3, 2, 49, 4, 256, DateTimeKind.Local).AddTicks(4230), "ivanov" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "Company", "Phone", "UserId" },
                values: new object[] { new Guid("7858f993-2ef3-41e0-8e20-cc41c3936161"), "123 Tech Street", "Tech Co", "123-456-7890", new Guid("dcc76bfb-750d-4cad-843c-2df443074875") });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Address", "CustomerId", "CustomerName", "DateFilled", "DatePlaced", "InvoiceNumber", "PaymentStatus", "Status", "Term" },
                values: new object[] { new Guid("545a3b9d-2474-4c40-90d5-fb9225bc28d1"), "123 Tech Street", new Guid("7858f993-2ef3-41e0-8e20-cc41c3936161"), "Ivan Ivanov", null, new DateTime(2024, 11, 3, 2, 49, 4, 264, DateTimeKind.Local).AddTicks(4508), 1001, 0, 0, 3 });

            migrationBuilder.InsertData(
                table: "LineItem",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("72126151-02b6-4846-93dd-e39f7b9543b0"), new Guid("545a3b9d-2474-4c40-90d5-fb9225bc28d1"), new Guid("ba9bb2d6-6f5f-4f13-82e8-78ab984970f7"), 2 },
                    { new Guid("98b48a19-e3fc-45b4-89a3-c6747b2dbe6c"), new Guid("545a3b9d-2474-4c40-90d5-fb9225bc28d1"), new Guid("e0661031-04ed-4bee-8a17-b6ae6bf79526"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_OrderId",
                table: "LineItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_ProductId",
                table: "LineItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
