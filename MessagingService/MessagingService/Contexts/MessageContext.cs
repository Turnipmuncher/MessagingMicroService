using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MessagingService.Models;

namespace MessagingService.Contexts
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options)
            :base(options) { }
        public MessageContext() { }
        public DbSet<Message> Message { get; set; }
    }
}
