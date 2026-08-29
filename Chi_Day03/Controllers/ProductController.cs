using Microsoft.AspNetCore.Mvc;
using Chi_Day03.Models;

namespace Chi_Day03.Controllers
{
    [Route("sảnphẩm")]
    public class ProductController : Controller
    {
        [Route("")]
        public IActionResult Index(int? categoryId)
        {
            var categories = new List<Category>
            {
                new Category { Id=1, Name="Vợt" },
                new Category { Id=2, Name="Quần áo" },
                new Category { Id=3, Name="Giày" },
            };

            var products = new List<Product>
            {
                new Product { Id=1, Name="Vợt lining màu trắng", Image="anh1.webp", Price=60000, SalePrice=35000, CategoryId=1, Description="Vợt lining trắng", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=2, Name="Vợt lining đỏ", Image="anh2.webp", Price=60000, SalePrice=35000, CategoryId=1, Description="Vợt lining đỏ", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=3, Name="Vợt hot trend", Image="anh3.jpg", Price=60000, SalePrice=35000, CategoryId=1, Description="Vợt hot trend", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=4, Name="Vợt yonex", Image="anh4.jpg", Price=60000, SalePrice=35000, CategoryId=1, Description="Vợt yonex", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=5, Name="Áo thể thao", Image="ao1.jpg", Price=60000, SalePrice=35000, CategoryId=2, Description="Áo thể thao", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=6, Name="Bộ đồ thể thao", Image="quanao1.jpg", Price=60000, SalePrice=35000, CategoryId=2, Description="Bộ đồ thể thao", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=7, Name="Giày thể thao", Image="giay1.jpg", Price=60000, SalePrice=35000, CategoryId=3, Description="Giày thể thao", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=8, Name="Giày thể thao màu hồng", Image="giay2.jpg", Price=60000, SalePrice=35000, CategoryId=3, Description="Giày thể thao màu hồng", Status=true, CreatedAt=DateTime.Now }
            };

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            ViewBag.Categories = categories;
            return View(products);
        }

        [Route("chi-tiet/{id}")]
        public IActionResult Details(int id)
        {
            var products = new List<Product>
            {
                new Product { Id=1, Name="Vợt lining màu trắng", Image="anh1.webp", Price=60000, SalePrice=35000, CategoryId=1, Description="Vợt lining trắng", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=2, Name="Vợt lining đỏ", Image="anh2.webp", Price=60000, SalePrice=35000, CategoryId=1, Description="Vợt lining đỏ", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=3, Name="Vợt hot trend", Image="anh3.jpg", Price=60000, SalePrice=35000, CategoryId=1, Description="Vợt hot trend", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=4, Name="Vợt yonex", Image="anh4.jpg", Price=60000, SalePrice=35000, CategoryId=1, Description="Vợt yonex", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=5, Name="Áo thể thao", Image="ao1.jpg", Price=60000, SalePrice=35000, CategoryId=2, Description="Áo thể thao", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=6, Name="Bộ đồ thể thao", Image="quanao1.jpg", Price=60000, SalePrice=35000, CategoryId=2, Description="Bộ đồ thể thao", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=7, Name="Giày thể thao", Image="giay1.jpg", Price=60000, SalePrice=35000, CategoryId=3, Description="Giày thể thao", Status=true, CreatedAt=DateTime.Now },
                new Product { Id=8, Name="Giày thể thao màu hồng", Image="giay2.jpg", Price=60000, SalePrice=35000, CategoryId=3, Description="Giày thể thao màu hồng", Status=true, CreatedAt=DateTime.Now }
            };

            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
