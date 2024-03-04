using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAPI.Entities;

namespace TodoAPI.Data.Map
{
    public class TodoItemsMap : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            //Define the table's name
            builder.ToTable("TodoItems");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title)
                .HasMaxLength(60);
            builder.Property(x => x.Content)
                .HasMaxLength(800);
            builder.Property(x => x.IsCompleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");


            // Many to Many relationship between Tags and Todo Items.
            builder.HasMany(x => x.Tags)
                .WithMany(x => x.TodoItems);
        }
    }
}
