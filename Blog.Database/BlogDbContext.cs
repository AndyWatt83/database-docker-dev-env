using Blog.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Database;

public class AppDbContext : DbContext
{
  public DbSet<BlogPost> Posts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseNpgsql("Host=postgres;Database=blog_database;Username=docker_user;Password=password");

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<BlogPost>().HasData(
      new BlogPost() { Id = 1, Title = "Doing Docker" },
      new BlogPost() { Id = 2, Title = "Angular with Docker" },
      new BlogPost() { Id = 3, Title = "Addicted to Docker - send help" }
    );
  }
}