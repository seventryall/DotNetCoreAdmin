using Jun.Admin.EntityFramework.Contract;
using Jun.Admin.Service.Contract;
using Jun.Admin.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.Service
{
    public class UserService : BaseService,IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ResponseData<UserDto> GetUser(string userName, string userPwd)
        {
            var res = DoInvoke<UserDto>(resp=> {
                var entity = _userRepository.GetUser(userName, userPwd);
                if (entity == null)
                {
                    resp.code = 101;
                    resp.msg ="用户名或密码错误";
                }
                else
                {
                    var dto = AutoMapperHelper.MapTo<UserDto>(entity);
                    resp.data = dto;
                }
            });
            return res;
        }
    }
}
