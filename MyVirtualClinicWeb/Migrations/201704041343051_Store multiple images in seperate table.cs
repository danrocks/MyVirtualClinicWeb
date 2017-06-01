namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Storemultipleimagesinseperatetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageModels", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ImageModels", new[] { "ApplicationUserId" });
            CreateTable(
                "dbo.VirtualClinicSubmissionModels",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        Upload = c.Guid(nullable: false),
                        PersonId = c.Int(nullable: false),
                        AuditWhen = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.SubmissionId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            DropTable("dbo.ImageModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageModels",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Upload = c.Guid(nullable: false),
                        PersonId = c.Int(nullable: false),
                        AuditWhen = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ImageId);
            
            DropForeignKey("dbo.VirtualClinicSubmissionModels", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.VirtualClinicSubmissionModels", new[] { "ApplicationUserId" });
            DropTable("dbo.VirtualClinicSubmissionModels");
            CreateIndex("dbo.ImageModels", "ApplicationUserId");
            AddForeignKey("dbo.ImageModels", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
