using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAPI.Models.Domain;

namespace NetCoreAPI.Data.EF
{
    internal static class EntityBuilderHelper
    {
        internal static void AddETraceMap<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : ETrace
        {
            builder.Property(e => e.CreationDate)
                .HasColumnName("creation_date")
                .IsRequired()
                .HasDefaultValueSql("now()");

            builder.Property(e => e.UpdateDate)
                .HasColumnName("update_date");

            builder.Property(e => e.Active)
                .HasColumnName("active")
                .HasDefaultValue(true);
        }
    }
}
