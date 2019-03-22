using Jun.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jun.Admin.EntityFramework
{
    public class Sys_MenuMap : IEntityTypeConfiguration<Sys_Menu>
    {
        public void Configure(EntityTypeBuilder<Sys_Menu> builder)
        {
            builder.ToTable("Sys_Menu");
            builder.Property(x => x.Name).HasMaxLength(20);
            builder.Property(x => x.Url).HasMaxLength(50);
            builder.Property(x => x.ParentID).HasMaxLength(50);
            builder.Property(x => x.Icon).HasMaxLength(20);
            builder.Property(x => x.Remark).HasMaxLength(200);
        }
    }
}
