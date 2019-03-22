using Jun.Admin.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.Service.Contract
{
    public interface IMenuFuncService
    {
        ResponseData<List<MenuTreeNodeDto>> GetMenuFuncTree();

        //ResponseData<List<MenuTreeNodeDto>> GetAllMenuFunc();

        //ResponseData<List<MenuTreeNodeDto>> GetUserAuthMenus(string userID);

        ResponseData<List<MenuTreeNodeDto>> GetUserAuthMenuFuncTree(string userID);


    }
}
