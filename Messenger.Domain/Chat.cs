using System;
using System.Collections.Generic;
using System.Text;
using Messenger.Domain.Auth;

namespace Messenger.Domain
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreationTime { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<ChatMember> ChatMembers { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}
