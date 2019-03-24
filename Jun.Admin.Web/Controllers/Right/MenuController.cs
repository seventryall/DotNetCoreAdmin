using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jun.Admin.Service.Contract;
using Jun.Admin.Web.Models;
using Jun.Admin.Web.Models.Right;
using Microsoft.AspNetCore.Mvc;

namespace Jun.Admin.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IFunctionService _funcService;

        public MenuController(IMenuService menuService,IFunctionService funcService)
        {
            _menuService = menuService;
            _funcService = funcService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMenuList()
        {
            var res = _menuService.GetMenuList();
            return Json(res);
        }

        public IActionResult GetRootMenus()
        {
            var res = _menuService.GetRootMenus();
            return Json(res);
        }

        public IActionResult GetSubMenus(string parentID)
        {
            var res = _menuService.GetSubMenus(parentID);
            return Json(res);
        }

        public IActionResult GetTreeRoots()
        {
            var res = _menuService.GetRootMenus();
            return Json(res);
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Insert()
        {
            var res = _funcService.GetFunctionList();
            return View(res.data);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}