using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TruongPhamNhatTien_3117410256.Data;
using TruongPhamNhatTien_3117410256.Models;

namespace TruongPhamNhatTien_3117410256.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CommerceDbContext _context;
        public HomeController(ILogger<HomeController> logger, CommerceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {

                var result = _context.Users.Where(s => s.Username.Equals(user.Username) && s.Password.Equals(user.Password)).ToList();
                if (result.Count() == 1)
                {
                    HttpContext.Session.Set("username", Encoding.ASCII.GetBytes(result.FirstOrDefault().Username));
                    return Redirect("/home");
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Users.Count(s => s.Username.Equals(user.Username));
                if (check == 0)
                {
                    if (user.Password.Equals(user.Confirm))
                    {
                        _context.Users.Add(user);
                        await _context.SaveChangesAsync();
                        HttpContext.Session.Set("username", Encoding.ASCII.GetBytes(user.Username));
                        return Redirect("/home");
                    }
                }
            }
            return Redirect("/home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return Redirect("/home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
