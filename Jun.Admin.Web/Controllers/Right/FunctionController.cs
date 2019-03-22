using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jun.Admin.Web.Models;
using Jun.Admin.Web.Models.Right;
using Microsoft.AspNetCore.Mvc;

namespace Jun.Admin.Web.Controllers.Right
{
    public class FunctionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetFuncList()
        {
            var respData = new ResponseData();
            var funcList = new List<Function>();
            funcList.Add(new Function
            {
                ID = "1",
                Name = "新增",
                Code = "Insert",
                Number = 1,
                CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
            });
            funcList.Add(new Function
            {
                ID = "2",
                Name = "修改",
                Code = "Update",
                Number = 2,
                CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
            });
            funcList.Add(new Function
            {
                ID = "3",
                Name = "删除",
                Code = "Delete",
                Number = 3,
                CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
            });
            funcList.Add(new Function
            {
                ID = "4",
                Name = "详情",
                Code = "Detail",
                Number = 4,
                CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
            });
            respData.data = funcList;
            return Json(respData);
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
    }
}