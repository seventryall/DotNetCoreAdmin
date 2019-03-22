using Jun.Admin.Entity;
using Jun.Admin.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Admin.Web
{
    public static class DbInitializer
    {
        public static void Initializer(AppDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Sys_User.Any())
            {
                return;
            }
            var users = new List<Sys_User>
            {
                new Sys_User {ID="09A19C87-ACE1-4A67-AFB9-CE7AA9E4C67B",UserName="admin",UserPwd="123",Email="admin123456@163.com",
                    Age =20,IsAdmin=true,Phone="13588888888",CreateTime=DateTime.Now},
            };
            users.ForEach(u => context.Sys_User.Add(u));
            context.SaveChanges();
        }
    }
}
