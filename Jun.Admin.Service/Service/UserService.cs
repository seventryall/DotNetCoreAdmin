using AutoMapper;
using Jun.Admin.EntityFramework.Contract;
using Jun.Admin.Service.Contract;
using Jun.Admin.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.Service
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public ResponseData<UserDto> GetUser(string userName, string userPwd)
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
                    var dto = _mapper.Map<UserDto>(entity);
                    resp.data = dto;
                }
            });
            return res;
        }

        public ResponseData<List<UserDto>> GetUserList()
        {
            var res = DoInvoke<List<UserDto>>(resp =>
            {
                var entities = _userRepository.GetAllUsers();
                var dtoList = _mapper.Map<List<UserDto>>(entities);
                resp.data = dtoList;

            });
            return res;
        }
    }
}
