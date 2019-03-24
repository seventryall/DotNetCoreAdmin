using Jun.Admin.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.Service.Contract
{
    public interface IMenuService
    {
        ResponseData<List<MenuTreeNodeDto>> GetMenuTree();

        ResponseData<List<MenuTreeNodeDto>> GetRootMenus();

        ResponseData<List<MenuTreeNodeDto>> GetSubMenus(string parentID);


        ResponseData<List<MenuTreeNodeDto>> GetUserAuthMenuTree(string userID);

        ResponseData<List<MenuDto>> GetMenuList();

        ResponseData<string> BuildLeftMenuHtml();
      


    }
}
