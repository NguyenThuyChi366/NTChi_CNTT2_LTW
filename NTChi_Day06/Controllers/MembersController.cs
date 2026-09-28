using Microsoft.AspNetCore.Mvc;
using NTChi_Day06.Models.DataModels;

namespace NTChi_Day06.Controllers
{
    public class MembersController : Controller
    {
        public static readonly List<Member> members = new List<Member>();
        public IActionResult Index()
        {
            return View(members);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Member member)
        {
            string msg = null;
            bool validate = true;
            if (member.UserName.Length < 3 || member.UserName.Length > 20)
            {
                msg = "<li>Tên đăng nhập phải có độ dài từ 3-20 ký tự </li>";
                validate = false;
            }
            if (!member.Email.Contains("@"))
            {
                msg += "<li>Email không đúng định dạng</li>";
                validate = false;
            }
            if (member.Birthday.AddYears(18) > DateTime.Now)
            {
                msg += "<li>Bạn chưa đủ 18 tuổi</li>";
                validate = false;
            }
            if (!member.Phone.StartsWith("0") || member.Phone.Length < 10 || member.Phone.Length > 12)
            {
                msg += "<li>Số điện thoại không hợp lệ</li>";
                validate = false;
            }
            if (validate)
            {
                member.MemberId = Guid.NewGuid().ToString();
                members.Add(member);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "<div class='alert alert-danger'>" + msg + "</div>";
                return View(member);
            }
        }
    }
}
