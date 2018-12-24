using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BasketBD.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryName = table.Column<string>(maxLength: 100, nullable: false),
                    SubCategory = table.Column<string>(maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SerialNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => new { x.CategoryName, x.SubCategory });
                });

            migrationBuilder.CreateTable(
                name: "ItemPicture",
                columns: table => new
                {
                    SlNo = table.Column<string>(maxLength: 100, nullable: false),
                    ItemCode = table.Column<string>(maxLength: 100, nullable: false),
                    PicturePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPicture", x => new { x.SlNo, x.ItemCode });
                });

            migrationBuilder.CreateTable(
                name: "NewArrival",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewArrival", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SlidePictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(maxLength: 500, nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlidePictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Mobile = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemCode = table.Column<string>(maxLength: 100, nullable: false),
                    BrandId = table.Column<string>(maxLength: 100, nullable: true),
                    Category = table.Column<string>(maxLength: 100, nullable: true),
                    EexpireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ItemName = table.Column<string>(maxLength: 100, nullable: true),
                    NewArrivalTitle = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "money", nullable: true),
                    SalePrice = table.Column<decimal>(type: "money", nullable: true),
                    SlideTitle = table.Column<string>(nullable: true),
                    SubCategory = table.Column<string>(maxLength: 100, nullable: true),
                    SupplierId = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemCode);
                    table.ForeignKey(
                        name: "FK__Items__BrandId__2D27B809",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Items__SupplierI__2C3393D0",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Items__2E1BDC42",
                        columns: x => new { x.Category, x.SubCategory },
                        principalTable: "Category",
                        principalColumns: new[] { "CategoryName", "SubCategory" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_BrandId",
                table: "Items",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SupplierId",
                table: "Items",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Category_SubCategory",
                table: "Items",
                columns: new[] { "Category", "SubCategory" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPicture");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "NewArrival");

            migrationBuilder.DropTable(
                name: "SlidePictures");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
