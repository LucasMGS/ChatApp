using Chat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities
{
    public class ChatRoomUser : EntityBase
    {
        public Guid ChatRoomId { get; private set; }
        public virtual ChatRoom? ChatRoom { get; private set; }
        public Guid UserId { get; private set; }
        public virtual User? User { get; private set; }
        public DateTimeOffset JoinedAt { get; private set; }

        public ChatRoomUser(Guid chatRoomId, Guid userId)
        {
            ChatRoomId = chatRoomId; 
            UserId = userId;
            JoinedAt = DateTimeOffset.UtcNow;
        }
    }
}
