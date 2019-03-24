using AutoMapper;
using Jun.Admin.Entity;
using Jun.Admin.EntityFramework.Contract;
using Jun.Admin.Service.Contract;
using Jun.Admin.Service.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jun.Admin.Service
{
    public class MenuService : BaseService, IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;


        public MenuService(IMenuRepository menuRepository,IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public ResponseData<List<MenuDto>> GetMenuList()
        {
            var res = DoInvoke<List<MenuDto>>(resp =>
            {
                var menus = _menuRepository.GetAllMenu();
                var dtos= _mapper.Map<List<MenuDto>>(menus);
                dtos.ForEach(d => {
                    d.ParentName = d.ParentMenu==null?"0":d.ParentMenu.Name;
                });
                resp.count = dtos.Count;
                resp.data = dtos;
            });
            return res;
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

        public ResponseData<List<MenuTreeNodeDto>> GetRootMenus()
        {
            var res = DoInvoke<List<MenuTreeNodeDto>>(resp =>
            {
                var menus = _menuRepository.GetRootMenus();
                var roots = new List<MenuTreeNodeDto>();
                menus.ToList().ForEach(m => {
                    roots.Add(new MenuTreeNodeDto
                    {
                        id = m.ID,
                        label = m.Name,
                        isLeaf = !m.IsParent ?? true
                    });
                });
                resp.data = roots;
            });
            return res;
        }

        public ResponseData<string> BuildLeftMenuHtml()
        {
            var res = DoInvoke<string>(resp =>
            {
                var sb = new StringBuilder();
                var menus = GetMenuTree();
                menus.data.ForEach(menu =>
                {
                    sb.Append("<li class=\"layui-nav-item\">");
                    if (menu.isLeaf)
                    {
                        sb.Append(string.Format("<a href=\"javascript:;\" lay-id=\"{0}\">{1}</a>",
                            menu.url, menu.label));
                    }
                    else
                    {
                        sb.Append(string.Format("<a href=\"javascript:;\">{0}</a>",menu.label));
                    }
                    BuildMenuHtml(sb, menu);
                    sb.Append("</li>");

                });
                resp.data = sb.ToString();
            });

                return res;
        }

        private void BuildMenuHtml(StringBuilder sb,MenuTreeNodeDto menu)
        {
            if (menu.children != null && menu.children.Count > 0)
            {
                sb.Append("<dl class=\"layui-nav-child\">");
                menu.children.ForEach(subMenu => {
                    sb.Append("<dd>");
                    if (subMenu.isLeaf)
                    {
                        sb.Append(string.Format("<a href=\"#\" lay-id =\"{0}\" tab-text=\"{1}\">{1}</a>",
                       subMenu.url, subMenu.label));
                    }
                    else
                    {
                        sb.Append(string.Format("<a href=\"#\">{0}</a>",subMenu.label));
                        BuildMenuHtml(sb, subMenu);
                    }
                    sb.Append("</dd>");
                });
                sb.Append("</dl>");
            }
        }

        public ResponseData<List<MenuTreeNodeDto>> GetSubMenus(string parentID)
        {
            var res = DoInvoke<List<MenuTreeNodeDto>>(resp =>
            {
                var menus = _menuRepository.GetSubMenus(parentID);
                var subMenus = new List<MenuTreeNodeDto>();
                menus.ToList().ForEach(m => {
                    subMenus.Add(new MenuTreeNodeDto
                    {
                        id = m.ID,
                        label = m.Name,
                        isLeaf = !m.IsParent ?? true
                    });
                });
                resp.data = subMenus;
            });
            return res;
        }



        public ResponseData<List<MenuTreeNodeDto>> GetUserAuthMenuTree(string userID)
        {
            var res = DoInvoke<List<MenuTreeNodeDto>>(resp =>
            {
                var menus = _menuRepository.GetUserAllAuthMenu(userID);
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
                node.isLeaf = !m.IsParent ?? true;
                node.url = m.Url;
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
                    node.isLeaf = !m.IsParent ?? true;
                    node.url = m.Url;
                    children.Add(node);
                    SetNodeChildren(menus, m.ID, node);
                });
            }
        }
    }
}
