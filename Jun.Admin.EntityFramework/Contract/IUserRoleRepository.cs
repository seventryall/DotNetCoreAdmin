using Jun.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.EntityFramework.Contract
{
    public interface IUserRoleRepository
    {
        IEnumerable<Sys_Role> GetUserRoles(string userID);
    }
}
