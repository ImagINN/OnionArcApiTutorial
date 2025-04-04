using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnionArc.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priorty = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Logo", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(2666), false, "https://picsum.photos/640/480/?image=81", "Sports, Books & Outdoors", new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(2876) },
                    { 2, new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(3364), true, "https://picsum.photos/640/480/?image=739", "Shoes, Computers & Automotive", new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(3364) },
                    { 3, new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(3422), false, "https://picsum.photos/640/480/?image=158", "Sports", new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(3422) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priorty", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2216), false, "Electronics", 0, 1, new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2216) },
                    { 2, new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2219), false, "Moda", 0, 2, new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2219) },
                    { 3, new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2221), false, "Computer", 1, 1, new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2221) },
                    { 4, new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2223), false, "Woman", 2, 1, new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2223) }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2219), "Aut oldular kalemi ki. Alias incidunt numquam ea ducimus quis sandalye voluptatem teldeki. Non commodi mi voluptatem.", false, "Gorgeous Fresh Bacon", new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2225) },
                    { 2, 2, new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2612), "Kapının voluptatem consequatur kapının nostrum ducimus beğendim. Türemiş kulu ea sinema olduğu odit un quia ama.", false, "Handcrafted Concrete Cheese", new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2612) },
                    { 3, 3, new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2697), "Quia sevindi göze quam. Değerli mutlu velit yapacakmış yaptı nemo eius çünkü.", true, "Gorgeous Metal Table", new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2698) },
                    { 4, 4, new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2803), "Aliquid eius sequi sarmal reprehenderit voluptate consequatur. De layıkıyla explicabo exercitationem doloremque tempora doğru gazete quia gülüyorum. Sandalye sarmal ipsa gazete aliquid esse illo blanditiis exercitationem.", false, "Rustic Plastic Table", new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2804) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(641), "Sed doloremque karşıdakine gitti et quia lambadaki quia aut bahar. Sarmal sevindi quia veniam voluptas sokaklarda. Adanaya illo vel camisi gülüyorum. Bilgiyasayarı sayfası oldular quam çünkü modi. Veniam illo çünkü için quia.", 15.001690656717500m, false, 570.573794045369800m, "Sleek Soft Car", new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(644) },
                    { 2, 2, new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(1017), "Alias salladı kulu adresini et. Enim aut gitti magnam çorba velit. Kapının quis cezbelendi olduğu batarya yaptı. Odio bahar rem minima veniam oldular koştum praesentium ut. Labore bilgisayarı de ut corporis quia umut uzattı.", 49.607322217246200m, false, 230.539759173509500m, "Fantastic Frozen Cheese", new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(1018) },
                    { 3, 3, new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(1068), "Autem blanditiis ekşili totam. Et çarpan aperiam.", 83.669411158911900m, false, 574.973106397681600m, "Unbranded Wooden Tuna", new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(1068) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
