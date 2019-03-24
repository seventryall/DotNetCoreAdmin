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

        public IEnumerable<Sys_Menu> GetRootMenus()
        {
            return GetMany(x => (x.IsDelete == false || x.IsDelete == null)&&x.ParentID=="0", 
                y => y.Number, false);

        }

        public IEnumerable<Sys_Menu> GetSubMenus(string parentID)
        {
            return GetMany(x => (x.IsDelete == false || x.IsDelete == null) && x.ParentID == parentID,
                y => y.Number, false);

        }


        public IEnumerable<Sys_Menu> GetUserAllAuthMenu(string userID)
        {
            var sql= @" with tab as
                       (
                         select ID,ParentID,Name,Url,Number,IsDelete from Sys_Menu where 
                         id in (select distinct(MenuID) from Sys_Role_Menu_Function where  roleid in (select RoleID from
                                 Sys_User_Role where UserID='" + userID + @"'))
                         union all
                         select b.ID,b.ParentId,b.Name,b.Url,b.Number,b.IsDelete
                         from
                         tab a,
                         sys_menu b 
                         where a.ParentId = b.ID
                         )
                        select distinct * from tab where IsDelete is null or IsDelete=0 order by number";
            //return FromSql(sql).ToList();sql返回信息需与实体保持一致
            return db.Database.SqlQuery<Sys_Menu>(sql);
        }
    }
}
