using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestApiEshop.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Lightweight 14\" laptop with AMD Ryzen 7, 16 GB RAM and 512 GB SSD.", "https://cdn.example.com/images/products/lenovo-ideapad-slim-5.jpg", "Lenovo IdeaPad Slim 5 14\"", 18990m },
                    { 2, "Fanless laptop with the Apple M3 chip, 8 GB unified memory and 256 GB SSD.", "https://cdn.example.com/images/products/macbook-air-13-m3.jpg", "Apple MacBook Air 13\" M3", 29990m },
                    { 3, "Gaming laptop with Intel Core i7, RTX 4070 and a 165 Hz display.", "https://cdn.example.com/images/products/asus-rog-strix-g16.jpg", "ASUS ROG Strix G16", 42990m },
                    { 4, "Compact Android flagship with a 6.2\" AMOLED display.", "https://cdn.example.com/images/products/samsung-galaxy-s24.jpg", "Samsung Galaxy S24 128GB", 21990m },
                    { 5, "6.1\" Super Retina XDR display, 48 MP camera and USB-C.", "https://cdn.example.com/images/products/iphone-15.jpg", "Apple iPhone 15 128GB", 22490m },
                    { 6, null, "https://cdn.example.com/images/products/redmi-note-13-pro.jpg", "Xiaomi Redmi Note 13 Pro", 7990m },
                    { 7, "Wireless over-ear headphones with active noise cancelling.", "https://cdn.example.com/images/products/sony-wh-1000xm5.jpg", "Sony WH-1000XM5", 8490m },
                    { 8, "Portable waterproof Bluetooth speaker.", "https://cdn.example.com/images/products/jbl-flip-6.jpg", "JBL Flip 6", 2790m },
                    { 9, "In-ear headphones with noise cancelling and MagSafe charging case.", "https://cdn.example.com/images/products/airpods-pro-2.jpg", "Apple AirPods Pro (2nd generation)", 6290m },
                    { 10, "27\" QHD Nano IPS gaming monitor, 180 Hz.", "https://cdn.example.com/images/products/lg-27gp850.jpg", "LG 27GP850 27\" Monitor", 8990m },
                    { 11, "27\" 4K USB-C hub monitor for office work.", "https://cdn.example.com/images/products/dell-u2723qe.jpg", "Dell UltraSharp U2723QE", 14490m },
                    { 12, null, "https://cdn.example.com/images/products/samsung-qled-q80c-55.jpg", "Samsung 55\" QLED Q80C", 21990m },
                    { 13, "Ergonomic wireless mouse with quiet clicks.", "https://cdn.example.com/images/products/logitech-mx-master-3s.jpg", "Logitech MX Master 3S", 2490m },
                    { 14, "75% wireless mechanical keyboard with hot-swappable switches.", "https://cdn.example.com/images/products/keychron-k2-pro.jpg", "Keychron K2 Pro", 2990m },
                    { 15, "Full HD 1080p webcam with stereo microphones.", "https://cdn.example.com/images/products/logitech-c920.jpg", "Logitech C920 HD Pro Webcam", 1690m },
                    { 16, "External USB 3.2 SSD with read speeds up to 1,050 MB/s.", "https://cdn.example.com/images/products/samsung-t7-1tb.jpg", "Samsung T7 Portable SSD 1TB", 2390m },
                    { 17, "3.5\" NAS hard drive.", "https://cdn.example.com/images/products/wd-red-plus-4tb.jpg", "WD Red Plus 4TB", 2890m },
                    { 18, null, "https://cdn.example.com/images/products/kingston-fury-beast-ddr5-32gb.jpg", "Kingston FURY Beast 32GB DDR5", 2690m },
                    { 19, "Dual-band Wi-Fi 6 router.", "https://cdn.example.com/images/products/tp-link-archer-ax55.jpg", "TP-Link Archer AX55", 1990m },
                    { 20, "2-bay NAS for home and small office.", "https://cdn.example.com/images/products/synology-ds224plus.jpg", "Synology DiskStation DS224+", 9490m },
                    { 21, "Game console with an Ultra HD Blu-ray drive.", "https://cdn.example.com/images/products/ps5-slim.jpg", "Sony PlayStation 5 Slim", 12990m },
                    { 22, "Hybrid console with a 7\" OLED screen.", "https://cdn.example.com/images/products/nintendo-switch-oled.jpg", "Nintendo Switch OLED", 8490m },
                    { 23, null, "https://cdn.example.com/images/products/xbox-wireless-controller.jpg", "Xbox Wireless Controller", 1490m },
                    { 24, "Smartwatch with an always-on Retina display.", "https://cdn.example.com/images/products/apple-watch-series-9.jpg", "Apple Watch Series 9 41mm", 10990m },
                    { 25, "GPS running watch with an AMOLED display.", "https://cdn.example.com/images/products/garmin-forerunner-265.jpg", "Garmin Forerunner 265", 10490m },
                    { 26, "6.8\" e-reader with adjustable warm light.", "https://cdn.example.com/images/products/kindle-paperwhite.jpg", "Kindle Paperwhite 16GB", 3990m },
                    { 27, "20,000 mAh power bank with USB-C Power Delivery.", "https://cdn.example.com/images/products/anker-powercore-20000.jpg", "Anker PowerCore 20000", 1190m },
                    { 28, "Three E27 smart bulbs with the Hue Bridge.", "https://cdn.example.com/images/products/philips-hue-starter-kit.jpg", "Philips Hue White and Color Starter Kit", 3490m },
                    { 29, "Robot vacuum cleaner with mopping and LiDAR navigation.", "https://cdn.example.com/images/products/roborock-q7-max.jpg", "Roborock Q7 Max", 7990m },
                    { 30, "Automatic espresso machine with a milk frother.", "https://cdn.example.com/images/products/delonghi-magnifica-s.jpg", "DeLonghi Magnifica S", 8990m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
