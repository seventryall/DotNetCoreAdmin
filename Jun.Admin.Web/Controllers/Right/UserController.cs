using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jun.Admin.Service.Contract;
using Jun.Admin.Web.Auth;
using Jun.Admin.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jun.Admin.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [PermissionFilter("/User/Index.View")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUserList()
        {
            var res = _userService.GetUserList();
            //var respData = new ResponseData();
            //respData.count = 50;
            //List<User> users = new List<User>();
            //for (int i = 0; i < 10; i++)
            //{
            //    var user = new User();
            //    user.ID = i.ToString();
            //    user.UserName = "username" + i;
            //    user.RealName = "realname" + i;
            //    user.Age = i;
            //    user.Email = "3857232" + i + "@qq.com";
            //    user.Phone = "135883945" + i;
            //    user.CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss");
            //    users.Add(user);
            //}
            //respData.data = users;
            return Json(res);
        }

        [PermissionFilter("/User/Index.Update")]
        public IActionResult Update()
        {
            return View();
        }

        [PermissionFilter("/User/Index.Insert")]
        public IActionResult Insert()
        {
            return View();
        }

        //用于测试
        public IActionResult Insert2()
        {
            return View("Insert");
        }

        [PermissionFilter("/User/Index.Detail")]
        public IActionResult Detail()
        {
            return View();
        }
    }
}