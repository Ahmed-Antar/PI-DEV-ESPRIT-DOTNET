using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class projectMap : EntityTypeConfiguration<project>
    {
        public projectMap()
        {
            // Primary Key
            this.HasKey(t => t.IdProject);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.Name)
                .HasMaxLength(255);

            this.Property(t => t.Priority)
                .HasMaxLength(255);

            this.Property(t => t.Type)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("project", "pmtbd");
            this.Property(t => t.IdProject).HasColumnName("IdProject");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Priority).HasColumnName("Priority");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Category_IdCategory).HasColumnName("Category_IdCategory");
            this.Property(t => t.id_user).HasColumnName("id_user");
            this.Property(t => t.id_team).HasColumnName("id_team");
            this.Property(t => t.id_client).HasColumnName("id_client");

            // Relationships
            this.HasOptional(t => t.category)
                .WithMany(t => t.projects)
                .HasForeignKey(d => d.Category_IdCategory);
            this.HasOptional(t => t.client)
                .WithMany(t => t.projects)
                .HasForeignKey(d => d.id_client);
            this.HasOptional(t => t.user)
                .WithMany(t => t.projects)
                .HasForeignKey(d => d.id_user);
            this.HasOptional(t => t.team)
                .WithMany(t => t.projects)
                .HasForeignKey(d => d.id_team);

        }
    }
}
