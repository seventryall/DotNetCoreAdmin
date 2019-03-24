using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jun.Admin.Service.Contract;
using Jun.Admin.Web.Models;
using Jun.Admin.Web.Models.Right;
using Microsoft.AspNetCore.Mvc;

namespace Jun.Admin.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService,IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Insert()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult GetRoleList()
        {
            var res = _roleService.GetRoleList();
            return Json(res);
            //var respData = new ResponseData();
            //List<Role> roles = new List<Role>();
            //roles.Add(
            //    new Role
            //    {
            //        ID = "1",
            //        Name = "管理员",
            //        Code = "Admin",
            //        Remark = "拥有所有权限",
            //    CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
            //    });
            //roles.Add(new Role
            //{
            //    ID = "2",
            //    Name = "普通用户",
            //    Code = "user",
            //    CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
            //});
            //respData.data = roles;
            //return Json(respData);
        }

    }
}