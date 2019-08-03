using MemeRSity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MemeRSity.Data
{
    public class ApplicationContext:IdentityDbContext<UserApp, IdentityRole, string>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContext) : base(dbContext)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleTag>()
                .HasKey(bc => new { bc.ArticleId, bc.TagId });  
            modelBuilder.Entity<ArticleTag>()
                .HasOne(bc => bc.Article)
                .WithMany(b => b.Tags)
                .HasForeignKey(bc => bc.ArticleId);  
            modelBuilder.Entity<ArticleTag>()
                .HasOne(bc => bc.Tag)
                .WithMany(c => c.Articles)
                .HasForeignKey(bc => bc.ArticleId);
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentRate> CommentRates { get; set; }
        public DbSet<UserApp> Users { get; set; }
    }
}