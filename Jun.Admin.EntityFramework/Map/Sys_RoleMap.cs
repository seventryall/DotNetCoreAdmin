using Jun.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jun.Admin.EntityFramework
{
    public class Sys_RoleMap : IEntityTypeConfiguration<Sys_Role>
    {
        public void Configure(EntityTypeBuilder<Sys_Role> builder)
        {
            builder.ToTable("Sys_Role");
            builder.Property(x => x.Name).HasMaxLength(20);
            builder.Property(x => x.Code).HasMaxLength(20);
            builder.Property(x => x.Remark).HasMaxLength(200);
        }
    }
}
