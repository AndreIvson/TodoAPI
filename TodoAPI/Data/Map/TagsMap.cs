using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAPI.Entities;

namespace TodoAPI.Data.Map
{
    public class TagsMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            //Define the table's name
            builder.ToTable("Tags");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
