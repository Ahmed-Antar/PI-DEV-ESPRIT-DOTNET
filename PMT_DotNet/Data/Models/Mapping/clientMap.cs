using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class clientMap : EntityTypeConfiguration<client>
    {
        public clientMap()
        {
            // Primary Key
            this.HasKey(t => t.IdClient);

            // Properties
            this.Property(t => t.City)
                .HasMaxLength(255);

            this.Property(t => t.Contact)
                .HasMaxLength(255);

            this.Property(t => t.Country)
                .HasMaxLength(255);

            this.Property(t => t.Email)
                .HasMaxLength(255);

            this.Property(t => t.Name)
                .HasMaxLength(255);

            this.Property(t => t.website)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("client", "pmtbd");
            this.Property(t => t.IdClient).HasColumnName("IdClient");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.website).HasColumnName("website");
        }
    }
}
