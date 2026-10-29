using RestApiEshop.Domain.Entities;

namespace RestApiEshop.Infrastructure.Mock
{
	public static class MockProductData
	{
		public static List<Product> GetProducts()
		{
			return
			[
				new() { Id = 1, Name = "Wireless Mouse", ImgUri = "https://example.com/images/wireless-mouse.jpg", Price = 499m, Description = "Compact wireless mouse with a USB dongle." },
				new() { Id = 2, Name = "Mechanical Keyboard", ImgUri = "https://example.com/images/mechanical-keyboard.jpg", Price = 2490m, Description = "Full-size keyboard with nechanical switches." },
				new() { Id = 3, Name = "27\" Monitor", ImgUri = "https://example.com/images/monitor-27.jpg", Price = 7800m, Description = "27\" 4k IPS monitor." },
				new() { Id = 4, Name = "USB-C Hub", ImgUri = "https://example.com/images/usb-c-hub.jpg", Price = 1299m, Description = null },
				new() { Id = 5, Name = "Noise Cancelling Headphones", ImgUri = "https://example.com/images/headphones.jpg", Price = 6000m, Description = null },
				new() { Id = 6, Name = "Full HD Webcam", ImgUri = "https://example.com/images/webcam.jpg", Price = 1500m, Description = "1080p webcam with a built-in microphone." },
				new() { Id = 7, Name = "External SSD 1TB", ImgUri = "https://example.com/images/external-ssd.jpg", Price = 2800m, Description = "Portable USB-C SSD." },
				new() { Id = 8, Name = "Laptop Stand", ImgUri = "https://example.com/images/laptop-stand.jpg", Price = 899m, Description = null },
				new() { Id = 9, Name = "Bluetooth Speaker", ImgUri = "https://example.com/images/bluetooth-speaker.jpg", Price = 1990m, Description = "Waterproof portable speaker." },
				new() { Id = 10, Name = "Office Chair", ImgUri = "https://example.com/images/office-chair.jpg", Price = 6490m, Description = "Ergonomic office chair." },
				new() { Id = 11, Name = "Smartwatch", ImgUri = "https://example.com/images/smartwatch.jpg", Price = 5100m, Description = null },
				new() { Id = 12, Name = "Power Bank 20000 mAh", ImgUri = "https://example.com/images/power-bank.jpg", Price = 999m, Description = "Power bank with USB-C fast charging." },
			];
		}
	}
}
