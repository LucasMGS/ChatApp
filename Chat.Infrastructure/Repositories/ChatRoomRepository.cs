using Chat.Domain.Contracts;
using Chat.Domain.Entities;
using Chat.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure.Repositories
{
    public class ChatRoomRepository : BaseRepository<ChatRoom>, IChatRoomRepository
    {
        public ChatRoomRepository(ChatContext chatContext) : base(chatContext)
        {
        }
    }
}
