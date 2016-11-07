using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class postMap : EntityTypeConfiguration<post>
    {
        public postMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPost);

            // Properties
            this.Property(t => t.Content)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("post", "pmtbd");
            this.Property(t => t.IdPost).HasColumnName("IdPost");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.PostDate).HasColumnName("PostDate");
            this.Property(t => t.Creator_id).HasColumnName("Creator_id");
            this.Property(t => t.topic_IdTopic).HasColumnName("topic_IdTopic");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.posts)
                .HasForeignKey(d => d.Creator_id);
            this.HasOptional(t => t.topic)
                .WithMany(t => t.posts)
                .HasForeignKey(d => d.topic_IdTopic);

        }
    }
}
