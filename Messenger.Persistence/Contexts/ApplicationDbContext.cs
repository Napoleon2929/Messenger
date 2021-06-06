using Messenger.Domain;
using Messenger.Domain.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Messenger.Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<ChatMember> ChatMembers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(b =>
            {
                b.HasMany<Message>(e => e.Messages)
                    .WithOne(e => e.User)
                    .HasForeignKey(x => x.AuthorId)
                    .IsRequired();

                b.HasMany<ChatMember>(e => e.ChatMembers)
                    .WithOne(e=>e.User)
                    .HasForeignKey(x => x.UserId);

                b.HasMany<Chat>(e => e.Chats)
                    .WithOne(e => e.User)
                    .HasForeignKey(x => x.CreatorId)
                    .IsRequired();

                b.Property(x => x.Email).IsRequired();
                b.Property(x => x.FirstName).IsRequired();
                b.Property(x => x.LastName).IsRequired();
            });

            builder.Entity<Chat>(b =>
            {
                b.HasMany<ChatMember>(e => e.ChatMembers)
                    .WithOne(e=>e.Chat)
                    .HasForeignKey(x => x.ChatId);

                b.HasMany<Message>(e => e.Messages)
                    .WithOne(e=>e.Chat)
                    .HasForeignKey(x => x.ChatId)
                    .IsRequired();

                b.HasKey(x => x.Id);
                b.Property(x => x.Name).IsRequired();
                b.Property(x => x.CreationTime).IsRequired();

                b.ToTable("Chats");
            });

            builder.Entity<Message>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Text).IsRequired(); 
                b.Property(x => x.CreationTime).IsRequired();

                b.ToTable("Messages");
            });

            builder.Entity<ChatMember>(b =>
            {
                b.HasKey(x => new {x.UserId, x.ChatId});

                b.ToTable("ChatMembers");
            });
        }
    }
}
