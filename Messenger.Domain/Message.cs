using Messenger.Domain.Auth;
using System;

namespace Messenger.Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid AuthorId { get; set; }

        public ApplicationUser User { get; set; }
        public Chat Chat { get; set; }
    }
}
