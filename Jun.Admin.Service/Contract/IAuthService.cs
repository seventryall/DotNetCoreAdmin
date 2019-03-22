using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.Service.Contract
{
    public interface IAuthService
    {
        bool CheckPermission(string userID, string permissionName);
    }
}
