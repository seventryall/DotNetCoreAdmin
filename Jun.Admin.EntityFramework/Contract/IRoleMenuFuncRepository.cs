using Jun.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.EntityFramework.Contract
{
    public interface IRoleMenuFuncRepository
    {
        IEnumerable<Sys_Role_Menu_Function> GetAllRoleMenuFunc();

        IEnumerable<Sys_Role_Menu_Function> GetUserAuthMenuFunc(string userID);

        IEnumerable<AuthMenuFuncView> GetUserAuthMenuFuncView(string userID);

    }
}
