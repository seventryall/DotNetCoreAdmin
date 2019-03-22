using Jun.Admin.Entity;
using Jun.Admin.EntityFramework.Contract;
using Jun.Admin.Service.Contract;
using Jun.Admin.Service.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Jun.Admin.Service
{
    public class MenuService : BaseService, IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public ResponseData<List<MenuTreeNodeDto>> GetMenuTree()
        {
            var res = DoInvoke<List<MenuTreeNodeDto>>(resp =>
            {
                var menus = _menuRepository.GetAllMenu();
                resp.data = GenMenuTree(menus);
            });
            return res;
        }

        public ResponseData<List<MenuTreeNodeDto>> GetUserAuthMenuTree(string userID)
        {
            var res = DoInvoke<List<MenuTreeNodeDto>>(resp =>
            {
                var menus = _menuRepository.GetUserAuthMenu(userID);
                resp.data = GenMenuTree(menus);
            });
            return res;
        }

        private List<MenuTreeNodeDto> GenMenuTree(IEnumerable<Sys_Menu> menus)
        {
            var nodes = new List<MenuTreeNodeDto>();
            if (menus == null)
                return nodes;
            var rootsMenu = menus.Where(m => m.ParentID == "0").ToList();
            rootsMenu.ForEach(m => {
                var node = new MenuTreeNodeDto();
                node.id = m.ID;
                node.label = m.Name;
                node.isLeaf = m.IsParent ?? true;
                nodes.Add(node);
                SetNodeChildren(menus, m.ID, node);
            });
            return nodes;
        }

        private void SetNodeChildren(IEnumerable<Sys_Menu> menus, string parentID, MenuTreeNodeDto pNode)
        {
            var subMenus = menus.Where(m => m.ParentID == parentID).ToList();
            if(subMenus.Count>0)
            {
                var children = new List<MenuTreeNodeDto>();
                pNode.children = children;
                subMenus.ForEach(m => {
                    var node = new MenuTreeNodeDto();
                    node.id = m.ID;
                    node.label = m.Name;
                    node.isLeaf = m.IsParent ?? true;
                    children.Add(node);
                    SetNodeChildren(menus, m.ID, node);
                });
            }
        }
    }
}
