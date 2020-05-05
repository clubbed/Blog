using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasOne(c => c.User).WithMany(c => c.Posts).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Post>().HasOne(c => c.Category).WithMany(c => c.Posts).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Post>().HasMany(c => c.Comments).WithOne(c => c.Post).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Post>().HasMany(c => c.Likes).WithOne(c => c.Post).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasMany(c => c.Posts).WithOne(c => c.Category).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comment>().HasOne(c => c.Post).WithMany(c => c.Comments).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Comment>().HasOne(c => c.User).WithMany(c => c.Comments).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>().HasKey(c => new { c.UserId, c.PostId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
