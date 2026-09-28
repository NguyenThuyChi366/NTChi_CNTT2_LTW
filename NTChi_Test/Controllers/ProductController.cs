using Microsoft.AspNetCore.Mvc;
using NTChi_Test.Models;

namespace NTChi_Test.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop Dell",
                    Price = 15000000,
                    Category = "Laptop",
                    Quantity = 10,
                    Description = "Laptop phục vụ học tập",
                    ImageUrl = "laptop-dell.jpg"
                },

                new Product
                {
                    Id = 2,
                    Name = "iPhone 15",
                    Price = 20000000,
                    Category = "Điện thoại",
                    Quantity = 5,
                    Description = "Điện thoại Apple",
                    ImageUrl = "iphone15.jpg"
                },

                new Product
                {
                    Id = 3,
                    Name = "Chuột Logitech",
                    Price = 500000,
                    Category = "Phụ kiện",
                    Quantity = 20,
                    Description = "Chuột không dây",
                    ImageUrl = "logitech.jpg"
                },

                new Product
                {
                    Id = 4,
                    Name = "Bàn phím cơ",
                    Price = 1200000,
                    Category = "Phụ kiện",
                    Quantity = 15,
                    Description = "Bàn phím cơ RGB",
                    ImageUrl = "keyboard.jpg"
                },

                new Product
                {
                    Id = 5,
                    Name = "Màn hình LG",
                    Price = 5000000,
                    Category = "Màn hình",
                    Quantity = 8,
                    Description = "Màn hình LG 24 inch",
                    ImageUrl = "monitor.jpg"
                },

                new Product
                {
                    Id = 6,
                    Name = "Samsung S24",
                    Price = 18000000,
                    Category = "Điện thoại",
                    Quantity = 7,
                    Description = "Điện thoại Samsung",
                    ImageUrl = "samsung-s24.jpg"
                }
            };

            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}