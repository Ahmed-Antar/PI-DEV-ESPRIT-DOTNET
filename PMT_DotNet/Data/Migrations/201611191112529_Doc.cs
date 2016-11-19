namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doc : DbMigration
    {
        public override void Up()
        {
            AddColumn("pmtbd.project", "DocumentsUrl", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("pmtbd.project", "DocumentsUrl");
        }
    }
}
