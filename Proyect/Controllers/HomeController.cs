using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyect.Models;
using Proyect.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
namespace Proyect.Controllers
{
        [Authorize]
    public class HomeController : Controller
    {
        public static float dinero;
        public static bool activado;

        private UserManager<ApplicationUser> _userManager { get; }

        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user.Id!=null){
                activado=true;
            }
            else{
                activado=false;
            }
            if (user == null)
            {
                return Challenge();//RedirectToAction( "Login", "Account");
            }
            foreach (var item in _context.Users)
            {
                if (item.Id == user.Id)
                {
                    var o = item.Efectivo.ToString();
                    double fcost = Convert.ToDouble(o);
                    float jo = (float)fcost;
                    dinero = jo;
                }
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
