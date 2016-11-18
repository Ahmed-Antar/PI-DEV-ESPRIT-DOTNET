using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class taskMap : EntityTypeConfiguration<task>
    {
        public taskMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Description, t.idProject });

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.idProject)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

           

            // Table & Column Mappings
            this.ToTable("task", "pmtbd");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.idProject).HasColumnName("idProject");
            this.Property(t => t.DeadLine).HasColumnName("DeadLine");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.id_user).HasColumnName("id_user");

            // Relationships
            this.HasRequired(t => t.project)
                .WithMany(t => t.tasks)
                .HasForeignKey(d => d.idProject);
            this.HasOptional(t => t.user)
                .WithMany(t => t.tasks)
                .HasForeignKey(d => d.id_user);

        }
    }
}
