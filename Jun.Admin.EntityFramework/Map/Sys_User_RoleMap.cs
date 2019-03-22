using Jun.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jun.Admin.EntityFramework
{
    public class Sys_User_RoleMap : IEntityTypeConfiguration<Sys_User_Role>
    {
        public void Configure(EntityTypeBuilder<Sys_User_Role> builder)
        {
            builder.ToTable("Sys_User_Role");
            builder.Property(x => x.UserID).HasMaxLength(50);
            builder.Property(x => x.RoleID).HasMaxLength(50);
        }
    }
}
