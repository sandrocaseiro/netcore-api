using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAPI.Models.Domain;

namespace NetCoreAPI.Data.EF.Configurations
{
    public class EUserRoleConfiguration : IEntityTypeConfiguration<EUserRole>
    {
        public void Configure(EntityTypeBuilder<EUserRole> builder)
        {
            builder.ToTable("user_role");

            builder.HasKey(e => new { e.UserId, e.RoleId });

            builder.Property(e => e.UserId)
                .HasColumnName("user_id");

            builder.Property(e => e.RoleId)
                .HasColumnName("role_id");

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(e => e.UserId);

            builder
                .HasOne(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId);
        }
    }
}
