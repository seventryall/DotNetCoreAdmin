using Jun.Admin.EntityFramework.Contract;
using Jun.Admin.Service.Contract;
using Jun.Admin.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;

namespace Jun.Admin.Service
{
    public class UserRoleService : BaseService, IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository userRoleRepository,
            IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        public ResponseData<List<RoleDto>> GetUserRoles(string userID)
        {
            var res = DoInvoke<List<RoleDto>>(resp =>
            {
                var entities = _userRoleRepository.GetUserRoles(userID);
                var list = new List<RoleDto>();
                entities.ToList().ForEach(r =>
                {
                    var dto = _mapper.Map<RoleDto>(r);
                    list.Add(dto);
                });
                resp.data = list;

            });
            return res;
        }
    }
}
