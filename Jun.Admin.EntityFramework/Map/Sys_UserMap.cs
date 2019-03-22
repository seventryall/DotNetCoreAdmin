using Jun.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jun.Admin.EntityFramework
{
    public class Sys_UserMap : IEntityTypeConfiguration<Sys_User>
    {
        public void Configure(EntityTypeBuilder<Sys_User> builder)
        {
            builder.ToTable("Sys_User");
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.UserName).HasMaxLength(20);
            builder.Property(x => x.RealName).HasMaxLength(20);
            builder.Property(x => x.UserPwd).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(50);

        }
    }
}
