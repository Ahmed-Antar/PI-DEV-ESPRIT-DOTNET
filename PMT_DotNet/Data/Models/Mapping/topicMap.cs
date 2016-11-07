using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class topicMap : EntityTypeConfiguration<topic>
    {
        public topicMap()
        {
            // Primary Key
            this.HasKey(t => t.IdTopic);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("topic", "pmtbd");
            this.Property(t => t.IdTopic).HasColumnName("IdTopic");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.LastUser).HasColumnName("LastUser");
            this.Property(t => t.ReplyDate).HasColumnName("ReplyDate");
            this.Property(t => t.Solved).HasColumnName("Solved");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Views).HasColumnName("Views");
            this.Property(t => t.Creator_id).HasColumnName("Creator_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.topics)
                .HasForeignKey(d => d.Creator_id);

        }
    }
}
