using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAPI.Models;

namespace TodoAPI.Data.Map
{
    public class TodoItemsMap : IEntityTypeConfiguration<TodoItemsModel>
    {
        public void Configure(EntityTypeBuilder<TodoItemsModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.IsComplete);
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
