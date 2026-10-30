using RestApiEshop.Domain.Entities;

namespace RestApiEshop.Infrastructure.Persistence.Seed
{
	internal static class ProductSeedData
	{
		private const string ImageBaseUri = "https://cdn.example.com/images/products/";

		public static readonly Product[] Products =
		[
			new() { Id = 1, Name = "Lenovo IdeaPad Slim 5 14\"", ImgUri = ImageBaseUri + "lenovo-ideapad-slim-5.jpg", Price = 18990m, Description = "Lightweight 14\" laptop with AMD Ryzen 7, 16 GB RAM and 512 GB SSD." },
			new() { Id = 2, Name = "Apple MacBook Air 13\" M3", ImgUri = ImageBaseUri + "macbook-air-13-m3.jpg", Price = 29990m, Description = "Fanless laptop with the Apple M3 chip, 8 GB unified memory and 256 GB SSD." },
			new() { Id = 3, Name = "ASUS ROG Strix G16", ImgUri = ImageBaseUri + "asus-rog-strix-g16.jpg", Price = 42990m, Description = "Gaming laptop with Intel Core i7, RTX 4070 and a 165 Hz display." },
			new() { Id = 4, Name = "Samsung Galaxy S24 128GB", ImgUri = ImageBaseUri + "samsung-galaxy-s24.jpg", Price = 21990m, Description = "Compact Android flagship with a 6.2\" AMOLED display." },
			new() { Id = 5, Name = "Apple iPhone 15 128GB", ImgUri = ImageBaseUri + "iphone-15.jpg", Price = 22490m, Description = "6.1\" Super Retina XDR display, 48 MP camera and USB-C." },
			new() { Id = 6, Name = "Xiaomi Redmi Note 13 Pro", ImgUri = ImageBaseUri + "redmi-note-13-pro.jpg", Price = 7990m, Description = null },
			new() { Id = 7, Name = "Sony WH-1000XM5", ImgUri = ImageBaseUri + "sony-wh-1000xm5.jpg", Price = 8490m, Description = "Wireless over-ear headphones with active noise cancelling." },
			new() { Id = 8, Name = "JBL Flip 6", ImgUri = ImageBaseUri + "jbl-flip-6.jpg", Price = 2790m, Description = "Portable waterproof Bluetooth speaker." },
			new() { Id = 9, Name = "Apple AirPods Pro (2nd generation)", ImgUri = ImageBaseUri + "airpods-pro-2.jpg", Price = 6290m, Description = "In-ear headphones with noise cancelling and MagSafe charging case." },
			new() { Id = 10, Name = "LG 27GP850 27\" Monitor", ImgUri = ImageBaseUri + "lg-27gp850.jpg", Price = 8990m, Description = "27\" QHD Nano IPS gaming monitor, 180 Hz." },
			new() { Id = 11, Name = "Dell UltraSharp U2723QE", ImgUri = ImageBaseUri + "dell-u2723qe.jpg", Price = 14490m, Description = "27\" 4K USB-C hub monitor for office work." },
			new() { Id = 12, Name = "Samsung 55\" QLED Q80C", ImgUri = ImageBaseUri + "samsung-qled-q80c-55.jpg", Price = 21990m, Description = null },
			new() { Id = 13, Name = "Logitech MX Master 3S", ImgUri = ImageBaseUri + "logitech-mx-master-3s.jpg", Price = 2490m, Description = "Ergonomic wireless mouse with quiet clicks." },
			new() { Id = 14, Name = "Keychron K2 Pro", ImgUri = ImageBaseUri + "keychron-k2-pro.jpg", Price = 2990m, Description = "75% wireless mechanical keyboard with hot-swappable switches." },
			new() { Id = 15, Name = "Logitech C920 HD Pro Webcam", ImgUri = ImageBaseUri + "logitech-c920.jpg", Price = 1690m, Description = "Full HD 1080p webcam with stereo microphones." },
			new() { Id = 16, Name = "Samsung T7 Portable SSD 1TB", ImgUri = ImageBaseUri + "samsung-t7-1tb.jpg", Price = 2390m, Description = "External USB 3.2 SSD with read speeds up to 1,050 MB/s." },
			new() { Id = 17, Name = "WD Red Plus 4TB", ImgUri = ImageBaseUri + "wd-red-plus-4tb.jpg", Price = 2890m, Description = "3.5\" NAS hard drive." },
			new() { Id = 18, Name = "Kingston FURY Beast 32GB DDR5", ImgUri = ImageBaseUri + "kingston-fury-beast-ddr5-32gb.jpg", Price = 2690m, Description = null },
			new() { Id = 19, Name = "TP-Link Archer AX55", ImgUri = ImageBaseUri + "tp-link-archer-ax55.jpg", Price = 1990m, Description = "Dual-band Wi-Fi 6 router." },
			new() { Id = 20, Name = "Synology DiskStation DS224+", ImgUri = ImageBaseUri + "synology-ds224plus.jpg", Price = 9490m, Description = "2-bay NAS for home and small office." },
			new() { Id = 21, Name = "Sony PlayStation 5 Slim", ImgUri = ImageBaseUri + "ps5-slim.jpg", Price = 12990m, Description = "Game console with an Ultra HD Blu-ray drive." },
			new() { Id = 22, Name = "Nintendo Switch OLED", ImgUri = ImageBaseUri + "nintendo-switch-oled.jpg", Price = 8490m, Description = "Hybrid console with a 7\" OLED screen." },
			new() { Id = 23, Name = "Xbox Wireless Controller", ImgUri = ImageBaseUri + "xbox-wireless-controller.jpg", Price = 1490m, Description = null },
			new() { Id = 24, Name = "Apple Watch Series 9 41mm", ImgUri = ImageBaseUri + "apple-watch-series-9.jpg", Price = 10990m, Description = "Smartwatch with an always-on Retina display." },
			new() { Id = 25, Name = "Garmin Forerunner 265", ImgUri = ImageBaseUri + "garmin-forerunner-265.jpg", Price = 10490m, Description = "GPS running watch with an AMOLED display." },
			new() { Id = 26, Name = "Kindle Paperwhite 16GB", ImgUri = ImageBaseUri + "kindle-paperwhite.jpg", Price = 3990m, Description = "6.8\" e-reader with adjustable warm light." },
			new() { Id = 27, Name = "Anker PowerCore 20000", ImgUri = ImageBaseUri + "anker-powercore-20000.jpg", Price = 1190m, Description = "20,000 mAh power bank with USB-C Power Delivery." },
			new() { Id = 28, Name = "Philips Hue White and Color Starter Kit", ImgUri = ImageBaseUri + "philips-hue-starter-kit.jpg", Price = 3490m, Description = "Three E27 smart bulbs with the Hue Bridge." },
			new() { Id = 29, Name = "Roborock Q7 Max", ImgUri = ImageBaseUri + "roborock-q7-max.jpg", Price = 7990m, Description = "Robot vacuum cleaner with mopping and LiDAR navigation." },
			new() { Id = 30, Name = "DeLonghi Magnifica S", ImgUri = ImageBaseUri + "delonghi-magnifica-s.jpg", Price = 8990m, Description = "Automatic espresso machine with a milk frother." },
		];
	}
}
