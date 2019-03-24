using Jun.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.EntityFramework.Contract
{
    public interface IMenuRepository
    {
        IEnumerable<Sys_Menu> GetAllMenu();

        IEnumerable<Sys_Menu> GetRootMenus();

        IEnumerable<Sys_Menu> GetSubMenus(string parentID);

        IEnumerable<Sys_Menu> GetUserAllAuthMenu(string userID);
    }
}
