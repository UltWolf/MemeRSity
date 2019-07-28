using MemeRSity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MemeRSity.Data
{
    public class ApplicationContext:IdentityDbContext<UserApp, IdentityRole, string>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentRate> CommentRates { get; set; }
        public DbSet<UserApp> Users { get; set; }
    }
}