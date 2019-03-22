using Jun.Admin.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.Service.Contract
{
    public interface IMenuService
    {
        ResponseData<List<MenuTreeNodeDto>> GetMenuTree();

        ResponseData<List<MenuTreeNodeDto>> GetUserAuthMenuTree(string userID);


        //ResponseData<List<MenuTreeNodeDto>> GetAllMenuFunc();

        //ResponseData<List<MenuTreeNodeDto>> GetUserAuthMenus(string userID);

        //ResponseData<List<MenuTreeNodeDto>> GetUserAuthMenuFuncs(string userID);


    }
}
