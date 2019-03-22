using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jun.Admin.Web.Models;
using Jun.Admin.Web.Models.Right;
using Microsoft.AspNetCore.Mvc;

namespace Jun.Admin.Web.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMenuList()
        {
            var respData = new ResponseData();
            List<Menu> menus = new List<Menu>();
            menus.Add(new Menu {
                ID="1",
                Name="权限管理",
                Url="#",
                Number=1,
                CreateTime= DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
            });
            menus.Add(new Menu
            {
                ID = "2",
                Name = "用户管理",
                Url = "/User/Index",
                Number = 11,
                ParentID="1",
                ParentName="权限管理",
                CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
            }); menus.Add(new Menu
            {
                ID = "3",
                Name = "菜单管理",
                Url = "/Menu/Index",
                Number = 12,
                ParentID = "1",
                ParentName = "权限管理",
                CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
        }); menus.Add(new Menu
            {
                ID = "4",
                Name = "角色管理",
                Url = "/Role/Index",
                Number = 13,
                ParentID = "1",
                ParentName = "权限管理",
                CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
        }); menus.Add(new Menu
            {
                ID = "5",
                Name = "功能管理",
                Url = "/Function/Index",
                Number = 14,
                ParentID = "1",
                ParentName = "权限管理",
                CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
        }); menus.Add(new Menu
            {
                ID = "6",
                Name = "权限分配",
                Url = "/Auth/Index",
                Number = 15,
                ParentID = "1",
                ParentName = "权限管理",
                CreateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss")
        });
            respData.data = menus;
            return Json(respData);
        }

        public IActionResult GetTreeAll()
        {
            var respData = new ResponseData();
            var nodes = new List<TreeNodeModel>();
            nodes = GenTreeTestData();
            respData.data = nodes;
            return Json(respData);
        }

        public IActionResult GetTreeRoots()
        {
            var respData = new ResponseData();
            var roots = new List<TreeNodeModel>();
            roots.Add(new TreeNodeModel { id = "1", label = "权限管理" });
            //roots.Add(new TreeNodeModel { id = "5", label = "河南省" });
            respData.data = roots;
            return Json(respData);

        }

        public IActionResult LoadChildren(string parentID)
        {
            var treeList = GenTreeTestData();
            TreeNodeModel parentNode = null;//new TreeNodeModel();
            parentNode = GetParentNode(parentID, parentNode, treeList);
            var respData = new ResponseData();
            if (parentNode != null && parentNode.children != null)
            {
                var children = new List<TreeNodeModel>();
                parentNode.children.ForEach(node =>
                {
                    node.children = null;
                    children.Add(node);
                });
                respData.data = children;
            }
            return Json(respData);

        }

        public TreeNodeModel GetParentNode(string parentID, TreeNodeModel parentNode, List<TreeNodeModel> ParentNodes)
        {
            if (ParentNodes != null)
            {
                foreach (var node in ParentNodes)
                {
                    if (parentNode != null)
                        break;
                    if (node.id == parentID)
                    {
                        parentNode = node;
                        break;
                    }
                    else
                    {
                        parentNode = GetParentNode(parentID, parentNode, node.children);
                    }
                }
            }
            return parentNode;
            //if (parentNode != null && parentNode.children != null)
            //{
            //    var children = new List<TreeNodeModel>();
            //    parentNode.children.ForEach(node =>
            //    {
            //        node.children = null;
            //        children.Add(node);
            //    });
            //    return children;

            //}
            //return new List<TreeNodeModel>();
        }

        public List<TreeNodeModel> GenTreeTestData()
        {
            List<TreeNodeModel> roots = new List<TreeNodeModel>();
            roots.Add(new TreeNodeModel
            {
                id = "1",
                label = "权限管理",
                children = new List<TreeNodeModel>() {
                new TreeNodeModel
                {
                    id ="2",
                    label ="用户管理"

                },
                new TreeNodeModel
                {
                    id ="3",
                    label ="角色管理"

                },
                new TreeNodeModel
                {
                    id ="4",
                    label ="菜单管理"

                },
                new TreeNodeModel
                {
                    id ="5",
                    label ="功能管理"

                },
                new TreeNodeModel
                {
                    id ="6",
                    label ="权限分配"

                }

            }
            });
            return roots;
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