using Chat.Domain.Entities;
using Chat.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infrastructure.Mappings;

public class UserMapping : EntityBaseMapping<User>
{

    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable(TableName.User, SchemaName.Chat);
        builder.Property(u => u.CreatedAt);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasOne(x => x.IdentityUser)
            .WithOne()
            .HasForeignKey<User>(x => x.IdentityUserId);

    }
}
