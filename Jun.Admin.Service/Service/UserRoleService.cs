using Jun.Admin.EntityFramework.Contract;
using Jun.Admin.Service.Contract;
using Jun.Admin.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Jun.Admin.Service
{
    public class UserRoleService : BaseService, IUserRoleService
    {
        private IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        public ResponseData<List<RoleDto>> GetUserRoles(string userID)
        {
            var res = DoInvoke<List<RoleDto>>(resp =>
            {
                var entities = _userRoleRepository.GetUserRoles(userID);
                var list = new List<RoleDto>();
                entities.ToList().ForEach(r =>
                {
                    var dto = AutoMapperHelper.MapTo<RoleDto>(r);
                    list.Add(dto);
                });
                resp.data = list;

            });
            return res;
        }
    }
}
