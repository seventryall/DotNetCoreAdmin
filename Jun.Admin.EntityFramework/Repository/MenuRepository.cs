using Jun.Admin.Entity;
using Jun.Admin.EntityFramework.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Jun.Admin.EntityFramework
{
    public class MenuRepository : AdminRepositoryBase<Sys_Menu>, IMenuRepository
    {
        public MenuRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Sys_Menu> GetAllMenu()
        {
            return GetMany(x => x.IsDelete == false || x.IsDelete == null, y => y.Number, false);
        }

        public IEnumerable<Sys_Menu> GetUserAuthMenu(string userID)
        {
            var sql= @" with tab as
                       (
                         select ID,ParentID,Name,Url,Number,IsDelete from Sys_Menu where 
                         exists (select distinct(MenuID) from Sys_Role_Menu_Function where  exists (select RoleID from
                                 Sys_User_Role where UserID='" + userID + @"')
                         union all
                         select b.Menu_ID,b.menu_ParentId,b.menu_name
                         from
                         tab a
                         sys_menu b 
                         where a.menu_ParentId = b.Menu_ID
                         )
                        select* from tab where IsDelete is null or IsDelete=0";
            return FromSql(sql).ToList();
        }
    }
}
