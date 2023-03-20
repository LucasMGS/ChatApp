using Chat.Core;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace Chat.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; private set; }
        public Guid IdentityUserId { get; private set; }
        public IdentityUser<Guid>? IdentityUser { get; private set; }

        private readonly List<ChatRoomUser> _chats = new ();
        public virtual IReadOnlyList<ChatRoomUser>? Chats => _chats.AsReadOnly();

        public User(string name, Guid identityUserId) 
        {
            Name = name;
            IdentityUserId = identityUserId;
        }
    }
}