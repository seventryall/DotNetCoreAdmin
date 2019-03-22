using Jun.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jun.Admin.EntityFramework
{
    public class Sys_Role_Menu_FunctionMap : IEntityTypeConfiguration<Sys_Role_Menu_Function>
    {
        public void Configure(EntityTypeBuilder<Sys_Role_Menu_Function> builder)
        {
            builder.ToTable("Sys_Role_Menu_Function");
            builder.Property(x => x.RoleID).HasMaxLength(50);
            builder.Property(x => x.MenuID).HasMaxLength(50);
            builder.Property(x => x.FunctionID).HasMaxLength(50);
        }
    }
}
