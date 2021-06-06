using System;
using System.Collections.Generic;
using System.Text;
using Messenger.Domain.Auth;

namespace Messenger.Domain
{
    public class ChatMember
    {
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }
        public Chat Chat { get; set; }
    }
}
