using Jun.Admin.EntityFramework.Contract;
using Jun.Admin.Service.Contract;
using Jun.Admin.Service.Dto;
using System.Linq;

namespace Jun.Admin.Service
{
    public class LoginService : BaseService, ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public LoginService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public ResponseData<UserDto> CheckLogin(string userName, string userPwd)
        {
            var res = DoInvoke<UserDto>(resp =>
            {
                var entity = _userRepository.GetUser(userName, userPwd);
                if (entity == null)
                {
                    resp.code = 101;
                    resp.msg = "用户名或密码错误";
                }
                else
                {
                    var dto = AutoMapperHelper.MapTo<UserDto>(entity);
                    resp.data = dto;
                    if (entity.IsAdmin != null && entity.IsAdmin.Value)
                    {
                        //获取所有菜单
                    }
                    var roles = _roleRepository.GetUserRoles(entity.ID);
                    var adminRole = roles.ToList().Where(a => a.Code == "admin").ToList();
                    if (adminRole.Count > 0)
                    {
                        //获取所有菜单
                    }
                    else
                    {
                        //获取角色菜单
                    }
                }
            });
            return res;
        }
    }
}
