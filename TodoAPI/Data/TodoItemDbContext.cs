using Microsoft.EntityFrameworkCore;
using TodoAPI.Data.Map;
using TodoAPI.Entities;

namespace TodoAPI.Data
{
    public class TodoItemDbContext : DbContext
    {
        public TodoItemDbContext(DbContextOptions<TodoItemDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoItemsMap());
            modelBuilder.ApplyConfiguration(new TagsMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
