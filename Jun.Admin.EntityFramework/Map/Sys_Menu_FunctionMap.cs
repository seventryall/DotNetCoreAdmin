using Jun.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jun.Admin.EntityFramework
{
    public class Sys_Menu_FunctionMap : IEntityTypeConfiguration<Sys_Menu_Function>
    {
        public void Configure(EntityTypeBuilder<Sys_Menu_Function> builder)
        {
            builder.ToTable("Sys_Menu_Function");
            builder.Property(x => x.MenuID).HasMaxLength(50);
            builder.Property(x => x.FunctionID).HasMaxLength(50);
        }
    }
}
