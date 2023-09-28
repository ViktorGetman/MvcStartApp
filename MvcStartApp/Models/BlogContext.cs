using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Models
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public sealed class BlogContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }
  
        /// Ссылка на таблицу UserPosts
        public DbSet<UserPost> UserPosts { get; set; }
        
        public DbSet<Request> Requests { get; set; }
 
        // Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options)  : base(options)
        {
            Database.EnsureCreated();
        }

        public BlogContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0LJBF47;Database=MvcStartApp;Trusted_Connection=true;TrustServerCertificate=true;");
        }
    }
}