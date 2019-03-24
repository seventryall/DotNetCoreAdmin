using Jun.Admin.Service.Contract;
using Jun.Admin.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jun.Admin.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMenuService _menuService;

        public HomeController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            var res = _menuService.BuildLeftMenuHtml();
            ViewData["LeftMenuHtml"] = res.data;
            var res2 = _menuService.GetRootMenus();
            return View(res2.data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Main()
        {
            return View();
        }

      
    }
}
