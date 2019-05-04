using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVA.Infrastructure.Data.Context.EntityConfigurations.Attribute
{
    public class AttributeConfiguration : IEntityTypeConfiguration<Domain.Attributes.Attribute>
    {
        public void Configure(EntityTypeBuilder<Domain.Attributes.Attribute> builder)
        {
            builder.ToTable("attributes");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id");
            builder.Property(b => b.CreatedDateTime).HasColumnName("created_date_time").IsRequired();
            builder.Property(b => b.ModifiedDateTime).HasColumnName("modified_date_time").IsRequired(false);
            builder.Property(b => b.Name).HasColumnName("name").HasMaxLength(128).IsRequired();
            builder.Property(b => b.Description).HasColumnName("description").IsRequired(false);
            builder.Property<int>("TypeId").HasColumnName("type_id").IsRequired();

            builder.HasOne(b => b.Type)
                .WithMany()
                .HasForeignKey("TypeId");
        }
    }
}