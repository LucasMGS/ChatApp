using Chat.Domain.Entities;
using Chat.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure.Mappings
{
    public class ChatRoomUserMapping : EntityBaseMapping<ChatRoomUser>
    {
        public override void Configure(EntityTypeBuilder<ChatRoomUser> builder)
        {
            base.Configure(builder);

            builder.ToTable(TableName.ChatRoomUser, SchemaName.Chat);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Chats)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.ChatRoom)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.ChatRoomId);
        }
    }
}
