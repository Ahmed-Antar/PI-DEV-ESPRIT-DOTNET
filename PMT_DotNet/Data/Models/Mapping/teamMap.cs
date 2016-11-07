using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class teamMap : EntityTypeConfiguration<team>
    {
        public teamMap()
        {
            // Primary Key
            this.HasKey(t => t.id_team);

            // Properties
            this.Property(t => t.nom_team)
                .HasMaxLength(255);

            this.Property(t => t.teamStatus)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("team", "pmtbd");
            this.Property(t => t.id_team).HasColumnName("id_team");
            this.Property(t => t.nom_team).HasColumnName("nom_team");
            this.Property(t => t.score).HasColumnName("score");
            this.Property(t => t.teamStatus).HasColumnName("teamStatus");
        }
    }
}
