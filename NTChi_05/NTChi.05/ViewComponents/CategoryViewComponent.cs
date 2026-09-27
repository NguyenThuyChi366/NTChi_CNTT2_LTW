using Microsoft.AspNetCore.Mvc;
using NTChi_05.Models;

namespace NTChi_05.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(bool? active)
        {
            var categories =  new List<Category>
            {
                new Category(){ CategoryId =1, CategoryName="Điện gia dụng", IsActive=true },
                new Category(){CategoryId=2,CategoryName="Iphone ", IsActive=true },
                new Category(){CategoryId=3,CategoryName="Làm đẹp ", IsActive=true },
                new Category(){CategoryId=4,CategoryName="Điện tử ", IsActive=false },

            };

            if(active != null)
            {
                categories = categories.Where(x => x.IsActive == active.Value).ToList();
            }
            return View(categories);
        } 
    }
}
