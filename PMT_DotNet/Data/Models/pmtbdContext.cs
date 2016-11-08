using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Models.Mapping;

namespace Data.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class pmtbdContext : DbContext
    {
        static pmtbdContext()
        {
            Database.SetInitializer<pmtbdContext>(null);
        }

        public pmtbdContext()
            : base("Name=pmtbdContext")
        {
        }

        public DbSet<category> categories { get; set; }
        public DbSet<client> clients { get; set; }
        public DbSet<post> posts { get; set; }
        public DbSet<project> projects { get; set; }
        public DbSet<task> tasks { get; set; }
        public DbSet<team> teams { get; set; }
        public DbSet<teammember> teammembers { get; set; }
        public DbSet<topic> topics { get; set; }
        public DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new categoryMap());
            modelBuilder.Configurations.Add(new clientMap());
            modelBuilder.Configurations.Add(new postMap());
            modelBuilder.Configurations.Add(new projectMap());
            modelBuilder.Configurations.Add(new taskMap());
            modelBuilder.Configurations.Add(new teamMap());
            modelBuilder.Configurations.Add(new teammemberMap());
            modelBuilder.Configurations.Add(new topicMap());
            modelBuilder.Configurations.Add(new userMap());
        }
    }
}
