using AutoMapper;
using Jun.Admin.Entity;
using Jun.Admin.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.Service
{
   public class AutoMapperAdminProfile:Profile
    {
        public AutoMapperAdminProfile()
        {
            CreateMap<Sys_User, UserDto>();
            CreateMap<UserDto, Sys_User>();
            CreateMap<Sys_Role, RoleDto>();
            CreateMap<RoleDto, Sys_Role>();
            CreateMap<Sys_Menu, MenuDto>();
            CreateMap<MenuDto, Sys_Menu>();
            CreateMap<Sys_Function, FunctionDto>();
            CreateMap<FunctionDto, Sys_Function>();

        }
    }
}
