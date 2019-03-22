using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jun.Admin.Service.Contract;
using Jun.Admin.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jun.Admin.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IMenuFuncService _menuFuncService;
        private readonly IUserRoleService _userRoleService;


        public AuthController(IMenuService menuService,IMenuFuncService menuFuncService)
        {
            _menuService = menuService;
            _menuFuncService = menuFuncService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMenuFuncTree()
        {
            var respData = new ResponseData();
            var nodeList = new List<TreeNodeModel>();
            nodeList.Add(new TreeNodeModel {
                id="1",
                label="权限管理",
                children=new List<TreeNodeModel> {
                    new TreeNodeModel{
                        id="2",
                        label="用户管理",
                        children=new List<TreeNodeModel>{
                            new TreeNodeModel{
                                id="3",
                                label="新增"
                            },
                            new TreeNodeModel{
                                id="4",
                                label="修改"
                            },
                              new TreeNodeModel{
                                id="5",
                                label="删除"
                            },
                                new TreeNodeModel{
                                id="6",
                                label="详情"
                            }

                        }
                        
                    },
                     new TreeNodeModel{
                        id="7",
                        label="角色管理",
                        children=new List<TreeNodeModel>{
                            new TreeNodeModel{
                                id="8",
                                label="新增"
                            },
                            new TreeNodeModel{
                                id="9",
                                label="修改"
                            },
                              new TreeNodeModel{
                                id="10",
                                label="删除"
                            },
                                new TreeNodeModel{
                                id="11",
                                label="详情"
                            }

                        }

                    },
                      new TreeNodeModel{
                        id="12",
                        label="菜单管理",
                        children=new List<TreeNodeModel>{
                            new TreeNodeModel{
                                id="13",
                                label="新增"
                            },
                            new TreeNodeModel{
                                id="14",
                                label="修改"
                            },
                              new TreeNodeModel{
                                id="15",
                                label="删除"
                            },
                                new TreeNodeModel{
                                id="16",
                                label="详情"
                            }

                        }

                    },
                       new TreeNodeModel{
                        id="17",
                        label="功能管理",
                        children=new List<TreeNodeModel>{
                            new TreeNodeModel{
                                id="18",
                                label="新增"
                            },
                            new TreeNodeModel{
                                id="19",
                                label="修改"
                            },
                              new TreeNodeModel{
                                id="20",
                                label="删除"
                            },
                                new TreeNodeModel{
                                id="21",
                                label="详情"
                            }

                        }

                    },
                        new TreeNodeModel{
                        id="22",
                        label="权限分配"
                    }

                }
            });
            respData.data = nodeList;
            return Json(respData);
        }

        public IActionResult GetAllMenuTree()
        {
            var res = _menuService.GetMenuTree();
            return Json(res);
        }

        public IActionResult GetAllMenuFuncTree()
        {
            var res = _menuFuncService.GetMenuFuncTree();
            return Json(res);
        }

        public IActionResult GetUserAuthMenuTree()
        {
            var res = _menuService.GetUserAuthMenuTree("");
            return Json(res);
        }

        public IActionResult GetUserAuthMenuFuncTree()
        {
            var res = _menuFuncService.GetUserAuthMenuFuncTree("");
            return Json(res);
        }

        public IActionResult GetUserRoles()
        {
            var res = _userRoleService.GetUserRoles("");
            return Json(res);

        }

        public IActionResult AdminTest()
        {
            return View();
        }

        public IActionResult UserTest()
        {
            return View();
        }
    }
}