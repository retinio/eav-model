using System;
using EVA.Domain.Entities.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVA.Infrastructure.Data.Context.EntityConfigurations.Relationships
{
    public class EntityRelationsConfiguration : IEntityTypeConfiguration<EntityRelations>
    {
        public void Configure(EntityTypeBuilder<EntityRelations> builder)
        {
            builder.ToTable("entity_relations");
            builder.HasKey(b => new { b.RelationId, b.ReferencedEntityId, b.ReferencingEntityId });
            
            builder.Property(b => b.RelationId).HasColumnName("relation_id").IsRequired();
            builder.Property(b => b.ReferencedEntityId).HasColumnName("referenced_entity_id").IsRequired();
            builder.Property(b=> b.ReferencingEntityId).HasColumnName("referencing_entity_id").IsRequired();
        }
    }
}