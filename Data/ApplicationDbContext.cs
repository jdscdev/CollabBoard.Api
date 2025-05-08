using CollabBoard.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollabBoard.Api.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Board> Boards => Set<Board>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<Comment> Comments => Set<Comment>();
    }
}