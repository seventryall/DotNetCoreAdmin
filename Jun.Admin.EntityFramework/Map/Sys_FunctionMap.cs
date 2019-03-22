using Jun.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jun.Admin.EntityFramework
{
    public class Sys_FunctionMap : IEntityTypeConfiguration<Sys_Function>
    {
        public void Configure(EntityTypeBuilder<Sys_Function> builder)
        {
            builder.ToTable("Sys_Function");
            builder.Property(x => x.Name).HasMaxLength(20);
            builder.Property(x => x.Code).HasMaxLength(20);

        }
    }
}
