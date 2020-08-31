using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationlessViews.Classes;

namespace MigrationlessViews.Configuration
{
    public class ViewConfiguration : IEntityTypeConfiguration<View>
    {
        public void Configure(EntityTypeBuilder<View> builder)
        {
            builder.HasNoKey();
        }
    }
}