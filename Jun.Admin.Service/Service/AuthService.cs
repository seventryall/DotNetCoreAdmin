using Jun.Admin.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Jun.Admin.Service
{
    public class AuthService : BaseService, IAuthService
    {
        public bool CheckPermission(string userID, string permissionName)
        {
            //获取用户权限
            var permissions = new List<Permission>()
            {

                new Permission { Name="/User/Index.View"},
                new Permission { Name="/User/Index.Detail"}
            };
            return permissions.Any(p => permissionName.StartsWith(p.Name));
        }

    }
}

