using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class teammemberMap : EntityTypeConfiguration<teammember>
    {
        public teammemberMap()
        {
            // Primary Key
            this.HasKey(t => t.idTeamMember);

            // Properties
            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.review)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("teammember", "pmtbd");
            this.Property(t => t.idTeamMember).HasColumnName("idTeamMember");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.idTeam).HasColumnName("idTeam");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.review).HasColumnName("review");
        }
    }
}
