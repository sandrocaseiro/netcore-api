using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetCoreAPI.Models.Domain;

namespace NetCoreAPI.Data.EF.Configurations
{
    public class ERoleConfiguration : IEntityTypeConfiguration<ERole>
    {
        public void Configure(EntityTypeBuilder<ERole> builder)
        {
            builder.ToTable("role");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            builder.AddETraceMap();
        }
    }
}
