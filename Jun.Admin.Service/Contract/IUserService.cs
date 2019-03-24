using Jun.Admin.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.Service.Contract
{
    public interface IUserService
    {
        ResponseData<UserDto> GetUser(string userName, string userPwd);

        ResponseData<List<UserDto>> GetUserList();


    }
}
