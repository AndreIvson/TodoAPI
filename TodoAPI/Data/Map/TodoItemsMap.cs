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
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title);
            builder.Property(x => x.Content);
            builder.Property(x => x.IsCompleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
