using Jun.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Jun.Admin.EntityFramework
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Sys_User> Sys_User { get; set; }
        public DbSet<Sys_Menu> Sys_Menu { get; set; }
        public DbSet<Sys_Role> Sys_Role { get; set; }
        public DbSet<Sys_Function> Sys_Function { get; set; }
        public DbSet<Sys_User_Role> Sys_User_Role { get; set; }
        public DbSet<Sys_Menu_Function> Sys_Menu_Function { get; set; }

        public DbSet<Sys_Role_Menu_Function> Sys_Role_Menu_Function { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)

        //{

        //    //添加数据库连接字符串

        //    builder.UseSqlServer(@"Server=.;User id=sa;Password=123;Database=JunAdminCore");

        //}

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new Sys_UserMap());
            //modelBuilder.ApplyConfiguration(new Sys_RoleMap());
            //modelBuilder.ApplyConfiguration(new Sys_MenuMap());
            //modelBuilder.ApplyConfiguration(new Sys_FunctionMap());
            //modelBuilder.ApplyConfiguration(new Sys_User_RoleMap());
            //modelBuilder.ApplyConfiguration(new Sys_Menu_FunctionMap());
            //modelBuilder.ApplyConfiguration(new Sys_Role_Menu_FunctionMap());

            base.OnModelCreating(modelBuilder);

            //添加FluentAPI配置

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().
                Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);

                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }

     
    }
}
