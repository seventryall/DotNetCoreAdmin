using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Jun.Admin.Web.Controllers.Right
{
    public class OtherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Score()
        {
            return View();
        }
    }
}