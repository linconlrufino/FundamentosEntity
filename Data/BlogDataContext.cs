using Blog.Data.Mappings;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PostWithTagsCount> PostWithTagsCount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433;Database=FluenteBlog;User ID=sa;Password=271198brL@!");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.Entity<PostWithTagsCount>(x =>
            {
                // x.ToSqlQuery("SELECT * FROM vwPostwithTags");
                x.ToSqlQuery(@"
                    SELECT 
                        [Title] AS [name],
                        SELECT COUNT([Id]) FROM [Tags] WHERE [PostId] = [Id]
                            As [Count]
                    FROM 
                        [Posts]");
            });
        }
    }
}