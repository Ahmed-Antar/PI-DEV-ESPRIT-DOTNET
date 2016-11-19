namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doc1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("project", "DocumentsUrl", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
        }
    }
}
