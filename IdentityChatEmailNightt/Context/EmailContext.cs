using IdentityChatEmailNightt.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityChatEmailNightt.Context
{
    public class EmailContext: IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=FURKAN;initial Catalog=EmailChatNightDb; integrated security=true;trust server certificate=true;");
        }
        public DbSet<Message> messages { get; set; }
    }
}

