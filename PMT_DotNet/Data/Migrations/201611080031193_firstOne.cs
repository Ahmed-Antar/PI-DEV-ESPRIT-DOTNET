namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "pmtbd.category",
                c => new
                    {
                        IdCategory = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdCategory);
            
            CreateTable(
                "pmtbd.project",
                c => new
                    {
                        IdProject = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 255, storeType: "nvarchar"),
                        EndDate = c.DateTime(precision: 0),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        Priority = c.String(maxLength: 255, storeType: "nvarchar"),
                        StartDate = c.DateTime(precision: 0),
                        Type = c.String(maxLength: 255, storeType: "nvarchar"),
                        Category_IdCategory = c.Int(),
                        id_user = c.Int(),
                        id_team = c.Int(),
                        id_client = c.Int(),
                    })
                .PrimaryKey(t => t.IdProject)
                .ForeignKey("pmtbd.category", t => t.Category_IdCategory)
                .ForeignKey("pmtbd.client", t => t.id_client)
                .ForeignKey("pmtbd.team", t => t.id_team)
                .ForeignKey("pmtbd.user", t => t.id_user)
                .Index(t => t.Category_IdCategory)
                .Index(t => t.id_user)
                .Index(t => t.id_team)
                .Index(t => t.id_client);
            
            CreateTable(
                "pmtbd.client",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        City = c.String(maxLength: 255, storeType: "nvarchar"),
                        Contact = c.String(maxLength: 255, storeType: "nvarchar"),
                        Country = c.String(maxLength: 255, storeType: "nvarchar"),
                        CreationDate = c.DateTime(precision: 0),
                        Email = c.String(maxLength: 255, storeType: "nvarchar"),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        Number = c.Int(),
                        website = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "pmtbd.task",
                c => new
                    {
                        Description = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        idProject = c.Int(nullable: false),
                        DeadLine = c.DateTime(precision: 0),
                        StartDate = c.DateTime(precision: 0),
                        state = c.String(maxLength: 255, storeType: "nvarchar"),
                        id_user = c.Int(),
                    })
                .PrimaryKey(t => new { t.Description, t.idProject })
                .ForeignKey("pmtbd.project", t => t.idProject, cascadeDelete: true)
                .ForeignKey("pmtbd.user", t => t.id_user)
                .Index(t => t.idProject)
                .Index(t => t.id_user);
            
            CreateTable(
                "pmtbd.user",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(maxLength: 255, storeType: "nvarchar"),
                        login = c.String(maxLength: 255, storeType: "nvarchar"),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        password = c.String(maxLength: 255, storeType: "nvarchar"),
                        role = c.String(maxLength: 255, storeType: "nvarchar"),
                        state = c.Int(nullable: false),
                        birthDay = c.DateTime(precision: 0),
                        country = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "pmtbd.post",
                c => new
                    {
                        IdPost = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 255, storeType: "nvarchar"),
                        PostDate = c.DateTime(precision: 0),
                        Creator_id = c.Int(),
                        topic_IdTopic = c.Int(),
                    })
                .PrimaryKey(t => t.IdPost)
                .ForeignKey("pmtbd.topic", t => t.topic_IdTopic)
                .ForeignKey("pmtbd.user", t => t.Creator_id)
                .Index(t => t.Creator_id)
                .Index(t => t.topic_IdTopic);
            
            CreateTable(
                "pmtbd.topic",
                c => new
                    {
                        IdTopic = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(precision: 0),
                        LastUser = c.Int(nullable: false),
                        ReplyDate = c.DateTime(precision: 0),
                        Solved = c.Int(nullable: false),
                        Title = c.String(maxLength: 255, storeType: "nvarchar"),
                        Views = c.Int(nullable: false),
                        Creator_id = c.Int(),
                    })
                .PrimaryKey(t => t.IdTopic)
                .ForeignKey("pmtbd.user", t => t.Creator_id)
                .Index(t => t.Creator_id);
            
            CreateTable(
                "pmtbd.team",
                c => new
                    {
                        id_team = c.Int(nullable: false, identity: true),
                        nom_team = c.String(maxLength: 255, storeType: "nvarchar"),
                        score = c.Int(nullable: false),
                        teamStatus = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id_team);
            
            CreateTable(
                "pmtbd.teammember",
                c => new
                    {
                        idTeamMember = c.Int(nullable: false, identity: true),
                        email = c.String(maxLength: 255, storeType: "nvarchar"),
                        idTeam = c.Int(nullable: false),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        review = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idTeamMember);
            
        }
        
        public override void Down()
        {
            DropForeignKey("pmtbd.project", "id_user", "pmtbd.user");
            DropForeignKey("pmtbd.project", "id_team", "pmtbd.team");
            DropForeignKey("pmtbd.task", "id_user", "pmtbd.user");
            DropForeignKey("pmtbd.post", "Creator_id", "pmtbd.user");
            DropForeignKey("pmtbd.post", "topic_IdTopic", "pmtbd.topic");
            DropForeignKey("pmtbd.topic", "Creator_id", "pmtbd.user");
            DropForeignKey("pmtbd.task", "idProject", "pmtbd.project");
            DropForeignKey("pmtbd.project", "id_client", "pmtbd.client");
            DropForeignKey("pmtbd.project", "Category_IdCategory", "pmtbd.category");
            DropIndex("pmtbd.topic", new[] { "Creator_id" });
            DropIndex("pmtbd.post", new[] { "topic_IdTopic" });
            DropIndex("pmtbd.post", new[] { "Creator_id" });
            DropIndex("pmtbd.task", new[] { "id_user" });
            DropIndex("pmtbd.task", new[] { "idProject" });
            DropIndex("pmtbd.project", new[] { "id_client" });
            DropIndex("pmtbd.project", new[] { "id_team" });
            DropIndex("pmtbd.project", new[] { "id_user" });
            DropIndex("pmtbd.project", new[] { "Category_IdCategory" });
            DropTable("pmtbd.teammember");
            DropTable("pmtbd.team");
            DropTable("pmtbd.topic");
            DropTable("pmtbd.post");
            DropTable("pmtbd.user");
            DropTable("pmtbd.task");
            DropTable("pmtbd.client");
            DropTable("pmtbd.project");
            DropTable("pmtbd.category");
        }
    }
}
