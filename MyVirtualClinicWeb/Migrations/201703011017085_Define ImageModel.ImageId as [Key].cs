namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefineImageModelImageIdasKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VirtualClientSubmissionModels",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Upload = c.Guid(nullable: false),
                        Img = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                        AuditWhen = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VirtualClientSubmissionModels", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.VirtualClientSubmissionModels", new[] { "ApplicationUserId" });
            DropTable("dbo.VirtualClientSubmissionModels");
        }
    }
}
