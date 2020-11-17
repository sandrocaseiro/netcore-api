using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApi.Models.Domain;

namespace NetCoreApi.Data.EF.Configurations
{
	public class EGroupConfiguration : IEntityTypeConfiguration<EGroup>
    {
        public void Configure(EntityTypeBuilder<EGroup> builder)
        {
            builder.ToTable("group");

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
