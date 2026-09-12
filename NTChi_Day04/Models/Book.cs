using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NTChi_Day04.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="1", Text="Nam Cao"},
            new SelectListItem {Value="2", Text="Ngô Tất Tố"},
            new SelectListItem {Value="3", Text="Adamkhoom"},
            new SelectListItem {Value="4", Text="Thiền sư Thích Nhất Hạnh"}
        };
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="1", Text="Truyện tranh"},
            new SelectListItem {Value="2", Text="Văn học đương đại"},
            new SelectListItem {Value="3", Text="Phật học phổ thông"},
            new SelectListItem {Value="4", Text="Truyện cười"}
        };

        public List<Book> GetBookList()
        {
            return new List<Book>()
            {
                new Book {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 2,
                    Image = "products/ChiPheo.jpg",
                    Price = 50000,
                    TotalPage = 200,
                    Summary = "Tác phẩm nổi tiếng của Nam Cao về cuộc đời Chí Phèo."
                },
                new Book {
                    Id = 2,
                    Title = "Lão Hạc",
                    AuthorId = 1,
                    GenreId = 2,
                    Image = "products/LaoHac.jpg",
                    Price = 40000,
                    TotalPage = 150,
                    Summary = "Câu chuyện cảm động về số phận người nông dân nghèo."
                },
                new Book {
                    Id = 3,
                    Title = "Tắt Đèn",
                    AuthorId = 2,
                    GenreId = 2,
                    Image = "products/TatDen.jpg",
                    Price = 60000,
                    TotalPage = 250,
                    Summary = "Tác phẩm hiện thực phê phán của Ngô Tất Tố."
                },
                new Book {
                    Id = 4,
                    Title = "Tích Chu",
                    AuthorId = 3,
                    GenreId = 1,
                    Image = "products/TichChu.jpg",
                    Price = 30000,
                    TotalPage = 100,
                    Summary = "Truyện cổ tích Việt Nam về lòng hiếu thảo."
                }
            };
        }

        // Lấy chi tiết sách theo Id
        public Book GetBookById(int id)
        {
            return this.GetBookList().FirstOrDefault(b => b.Id == id);
        }
    }
}
