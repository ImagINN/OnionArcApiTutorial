using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArc.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixedBugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Logo", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://picsum.photos/id/1011/200/300", "Elektronik", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Logo", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://picsum.photos/id/1012/200/300", "Mobilya", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Logo", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://picsum.photos/id/1013/200/300", "Giyim", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orta segment akıllı telefon. Uygun fiyatlı ve kaliteli.", "Samsung Galaxy A52", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kış ayları için kalın, su geçirmez mont.", "Erkek Mont", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek performanslı, oyun odaklı dizüstü bilgisayar.", "Gaming Laptop", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Günlük kullanım için şık ve rahat elbise.", "Kadın Elbise", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek ses kalitesi, uzun pil ömrü ile kablosuz kulaklık.", 15.0m, 349.99m, "Bluetooth Kulaklık", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hakiki deriden üretilmiş, çok bölmeli erkek cüzdanı.", 10.0m, 199.90m, "Deri Cüzdan", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "RGB ışıklı, yüksek hassasiyetli gaming mouse.", 20.0m, 499.00m, "Oyuncu Mouse", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Logo", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(2666), "https://picsum.photos/640/480/?image=81", "Sports, Books & Outdoors", new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(2876) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Logo", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(3364), "https://picsum.photos/640/480/?image=739", "Shoes, Computers & Automotive", new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(3364) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Logo", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(3422), "https://picsum.photos/640/480/?image=158", "Sports", new DateTime(2025, 4, 4, 16, 25, 8, 55, DateTimeKind.Utc).AddTicks(3422) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2216), new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2216) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2219), new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2219) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2221), new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2221) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2223), new DateTime(2025, 4, 4, 16, 25, 8, 56, DateTimeKind.Utc).AddTicks(2223) });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2219), "Aut oldular kalemi ki. Alias incidunt numquam ea ducimus quis sandalye voluptatem teldeki. Non commodi mi voluptatem.", "Gorgeous Fresh Bacon", new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2225) });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2612), "Kapının voluptatem consequatur kapının nostrum ducimus beğendim. Türemiş kulu ea sinema olduğu odit un quia ama.", "Handcrafted Concrete Cheese", new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2612) });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2697), "Quia sevindi göze quam. Değerli mutlu velit yapacakmış yaptı nemo eius çünkü.", "Gorgeous Metal Table", new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2698) });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2803), "Aliquid eius sequi sarmal reprehenderit voluptate consequatur. De layıkıyla explicabo exercitationem doloremque tempora doğru gazete quia gülüyorum. Sandalye sarmal ipsa gazete aliquid esse illo blanditiis exercitationem.", "Rustic Plastic Table", new DateTime(2025, 4, 4, 16, 25, 8, 68, DateTimeKind.Utc).AddTicks(2804) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(641), "Sed doloremque karşıdakine gitti et quia lambadaki quia aut bahar. Sarmal sevindi quia veniam voluptas sokaklarda. Adanaya illo vel camisi gülüyorum. Bilgiyasayarı sayfası oldular quam çünkü modi. Veniam illo çünkü için quia.", 15.001690656717500m, 570.573794045369800m, "Sleek Soft Car", new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(644) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(1017), "Alias salladı kulu adresini et. Enim aut gitti magnam çorba velit. Kapının quis cezbelendi olduğu batarya yaptı. Odio bahar rem minima veniam oldular koştum praesentium ut. Labore bilgisayarı de ut corporis quia umut uzattı.", 49.607322217246200m, 230.539759173509500m, "Fantastic Frozen Cheese", new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(1018) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(1068), "Autem blanditiis ekşili totam. Et çarpan aperiam.", 83.669411158911900m, 574.973106397681600m, "Unbranded Wooden Tuna", new DateTime(2025, 4, 4, 16, 25, 8, 72, DateTimeKind.Utc).AddTicks(1068) });
        }
    }
}
