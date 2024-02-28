using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TodoAPI.Data.Map;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public class TodoItemDbContext : DbContext
    {
        public TodoItemDbContext(DbContextOptions<TodoItemDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItemsModel> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoItemsMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
