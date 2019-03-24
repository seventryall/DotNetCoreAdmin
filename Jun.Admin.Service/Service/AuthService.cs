using Jun.Admin.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Jun.Admin.EntityFramework.Contract;

namespace Jun.Admin.Service
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IRoleMenuFuncRepository _roleMenuFuncRepository;

        public AuthService(IRoleMenuFuncRepository roleMenuFuncRepository)
        {
            _roleMenuFuncRepository = roleMenuFuncRepository;
        }

        public bool CheckPermission(string userID, string permissionName)
        {
            //获取用户权限
            userID = "AFF4F87C-F715-46D0-B79A-66184EDA08C9";
            var list = _roleMenuFuncRepository.GetUserAllAuthMenuFuncView(userID);
            var permissions = new List<Permission>();
            list.ToList().ForEach(a => {
                permissions.Add(new Permission {
                    Name = string.Format("{0}.{1}", a.Menu.Url, a.Function.Code)
                });
            });

            //var permissions = new List<Permission>()
            //{

            //    new Permission { Name="/User/Index.View"},
            //    new Permission { Name="/User/Index.Detail"}
            //};
            return permissions.Any(p => permissionName.StartsWith(p.Name));
        }

    }
}

