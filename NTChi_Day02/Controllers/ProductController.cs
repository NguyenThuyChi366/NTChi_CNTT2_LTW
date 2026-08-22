using Microsoft.AspNetCore.Mvc;
using NTChi_Day02.Models; 
namespace NTChi_Day02.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 100000, CreatedAt = DateTime.Parse("2026-06-03"), Image = "anh1.webp" },
                new Product { Id = 2, Name = "Product 2", Price = 120000, CreatedAt = DateTime.Parse("2025-12-24"), Image = "anh2.webp" },
                new Product { Id = 3, Name = "Product 3", Price = 50000, CreatedAt = DateTime.Parse("2024-09-25"), Image = "anh3.jpg " },
                new Product { Id = 4, Name = "Product 4", Price = 650000, CreatedAt = DateTime.Parse("2026-02-02"), Image = "anh4.jpg " }
            };

            return View(products);
        }
    }
}
