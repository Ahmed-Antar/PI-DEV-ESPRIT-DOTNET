using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class categoryMap : EntityTypeConfiguration<category>
    {
        public categoryMap()
        {
            // Primary Key
            this.HasKey(t => t.IdCategory);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("category", "pmtbd");
            this.Property(t => t.IdCategory).HasColumnName("IdCategory");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
