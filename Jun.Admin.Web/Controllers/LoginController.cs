using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Jun.Admin.Service.Contract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Jun.Admin.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(string userName, string userPwd)
        {
            var res = _loginService.CheckLogin(userName, userPwd);
            if (res.code == 0)
            {
                var claims = new[] {
                   // new Claim("UserName", res.data.UserName) ,
                    //new Claim("UserID", res.data.ID)
                    new Claim(ClaimTypes.NameIdentifier,res.data.ID),
                    new Claim(ClaimTypes.Name,res.data.UserName),
                   // new Claim(ClaimTypes.Role,"admin"),
                };

                var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal user = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);

                //Task.Run(async () =>
                //{
                //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                //}).Wait();
            }
            return Json(res);
        }

        public async Task<IActionResult> Logout(string returnurl)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect(returnurl ?? "/Login/Index");
        }
    }
}