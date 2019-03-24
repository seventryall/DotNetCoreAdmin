using Jun.Admin.Entity;
using Jun.Admin.EntityFramework.Contract;
using Jun.Admin.Service.Contract;
using Jun.Admin.Service.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Jun.Admin.Service
{
    public class MenuFuncService : BaseService, IMenuFuncService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IFunctionRepository _functionRepository;
        private readonly IMenuFuncRepository _menuFuncRepository;
        private readonly IRoleMenuFuncRepository _roleMenuFuncRepository;

        public MenuFuncService(IMenuRepository menuRepository, IMenuFuncRepository menuFuncRepository,
            IFunctionRepository functionRepository, IRoleMenuFuncRepository roleMenuFuncRepository)
        {
            _menuRepository = menuRepository;
            _functionRepository = functionRepository;
            _menuFuncRepository = menuFuncRepository;
            _roleMenuFuncRepository = roleMenuFuncRepository;
        }

        public ResponseData<List<MenuTreeNodeDto>> GetMenuFuncTree()
        {
            var res = DoInvoke<List<MenuTreeNodeDto>>(resp =>
            {
                var menus = _menuRepository.GetAllMenu();
                var funcs = _functionRepository.GetAllFunction();
                var menuFuncs = _menuFuncRepository.GetAllMenuFunc();
                resp.data = BuildMenuFuncTree(menus, funcs, menuFuncs);
            });
            return res;
        }

        public ResponseData<List<MenuTreeNodeDto>> GetUserAuthMenuFuncTree(string userID)
        {
            var res = DoInvoke<List<MenuTreeNodeDto>>(resp =>
            {
                var menus = _menuRepository.GetAllMenu();
                var funcs = _functionRepository.GetAllFunction();
                var menuFuncs = _menuFuncRepository.GetAllMenuFunc();
                var authMenuFuncs = _roleMenuFuncRepository.GetUserAllAuthMenuFunc(userID);
                var nodes = BuildMenuFuncTree(menus, funcs, menuFuncs);
                SetTreeChecked(nodes, authMenuFuncs);
                resp.data = nodes;
            });
            return res;
        }

        private void SetTreeChecked(List<MenuTreeNodeDto> nodes, IEnumerable<Sys_Role_Menu_Function> authMenuFuncs)
        {
            if (nodes == null)
                return;
            nodes.ForEach(pNode =>
            {
                SetNodeChecked(pNode, authMenuFuncs);
            });
        }

        private void SetNodeChecked(MenuTreeNodeDto pNode, IEnumerable<Sys_Role_Menu_Function> authMenuFuncs)
        {
            if (pNode.children != null && pNode.children.Count > 0)
            {
                var isLeaf = pNode.children.Any(x => x.isLeaf);
                if (isLeaf)
                {
                    pNode.children.ForEach(subNode =>
                    {
                        var count = authMenuFuncs.Count(x => x.MenuID == pNode.id && x.FunctionID == subNode.id);
                        subNode.@checked = count > 0;
                    });
                }
                else
                {
                    pNode.children.ForEach(subNode =>
                    {
                        SetNodeChecked(subNode, authMenuFuncs);
                    });
                }
            }

        }

        private List<MenuTreeNodeDto> BuildMenuFuncTree(IEnumerable<Sys_Menu> menus, IEnumerable<Sys_Function> funcs,
            IEnumerable<Sys_Menu_Function> menuFuncs)
        {
            var nodes = new List<MenuTreeNodeDto>();
            if (menus == null)
                return nodes;
            var rootsMenu = menus.Where(m => m.ParentID == "0").ToList();
            rootsMenu.ForEach(m =>
            {
                var node = new MenuTreeNodeDto();
                node.id = m.ID;
                node.label = m.Name;
                node.isLeaf = !m.IsParent ?? true;
                nodes.Add(node);
                SetNodeChildren(menus, funcs, menuFuncs, node);
            });
            return nodes;
        }


        private void SetNodeChildren(IEnumerable<Sys_Menu> menus, IEnumerable<Sys_Function> funcs,
            IEnumerable<Sys_Menu_Function> menuFuncs, MenuTreeNodeDto pNode)
        {
            var subMenus = menus.Where(m => m.ParentID == pNode.id).ToList();
            if (subMenus.Count > 0)
            {
                var children = new List<MenuTreeNodeDto>();
                pNode.children = children;
                subMenus.ForEach(m =>
                {
                    var node = new MenuTreeNodeDto();
                    node.id = m.ID;
                    node.label = m.Name;
                    node.isLeaf = !m.IsParent ?? true;
                    children.Add(node);
                    SetNodeChildren(menus, funcs, menuFuncs, node);
                });
            }
            else
            {
                SetFuncChildren(pNode, funcs, menuFuncs);
            }
        }

        private void SetFuncChildren(MenuTreeNodeDto pNode, IEnumerable<Sys_Function> funcs,
            IEnumerable<Sys_Menu_Function> menuFunc)
        {
            var subMenuFuncs = menuFunc.Where(mf => mf.MenuID == pNode.id).ToList();
            if (subMenuFuncs.Count == 0)
                return;
            var children = new List<MenuTreeNodeDto>();
            pNode.children = children;
            pNode.isLeaf = false;
            subMenuFuncs.ForEach(mf =>
            {
                var node = new MenuTreeNodeDto();
                node.id = mf.FunctionID;
                var func = funcs.SingleOrDefault(f => f.ID == mf.FunctionID);
                node.label = func == null ? "" : func.Name;
                node.isLeaf = true;
                node.Number = func == null ? 0 : func.Number ?? 0;
                children.Add(node);
            });
            pNode.children= children.OrderBy(n=>n.Number).ToList();
        }


    }
}
