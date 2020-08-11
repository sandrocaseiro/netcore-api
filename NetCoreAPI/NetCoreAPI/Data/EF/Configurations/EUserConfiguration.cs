using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAPI.Models.Domain;

namespace NetCoreAPI.Data.EF.Configurations
{
    public class EUserConfiguration : IEntityTypeConfiguration<EUser>
    {
        public void Configure(EntityTypeBuilder<EUser> builder)
        {
            builder.ToTable("user");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Cpf)
                .HasColumnName("cpf")
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.Balance)
                .HasColumnName("balance")
                .HasColumnType("numeric(19,4)");

            builder.Property(e => e.GroupId)
                .HasColumnName("group_id");

            builder
                .HasOne(e => e.Group)
                .WithMany()
                .HasForeignKey(e => e.GroupId);

            builder.AddETraceMap();
        }
    }
}
