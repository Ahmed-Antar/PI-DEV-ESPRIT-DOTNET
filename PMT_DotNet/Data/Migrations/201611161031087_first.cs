namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AlterColumn("pmtbd.task", "state", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("pmtbd.task", "state", c => c.String(maxLength: 255, storeType: "nvarchar"));
        }
    }
}
