using AdminNotificator.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminNotificator.Core.TablesConfigration;

public class EmailTypeConfiguration : IEntityTypeConfiguration<EmailType>
{
    public void Configure(EntityTypeBuilder<EmailType> builder)
    {
        builder.HasKey(x => x.Id);
    }
}