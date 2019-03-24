using AutoMapper;
using Jun.Admin.EntityFramework.Contract;
using Jun.Admin.Service.Contract;
using Jun.Admin.Service.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Jun.Admin.Service
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository,
            IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

         public ResponseData<List<RoleDto>> GetRoleList()
        {
            var res = DoInvoke<List<RoleDto>>(resp =>
            {
                var entities = _roleRepository.GetAllRole();
                var dtoList = _mapper.Map<List<RoleDto>>(entities);
                resp.data = dtoList;

            });
            return res;
        }
    }
}
