using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Messenger.Domain.Auth
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Message> Messages { get; set; }
        public ICollection<ChatMember> ChatMembers { get; set; }
        public ICollection<Chat> Chats { get; set; } 
    }
}
