using EasyChat.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectName.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // Определяем коллекцию для наших сообщений
        public DbSet<MyMessage> Messages { get; set; }
    }
}