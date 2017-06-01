namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FurtherWorkaroundmultipleimages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageModels",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SubmissionId, t.Image })
                .ForeignKey("dbo.VirtualClinicSubmissionModels", t => t.SubmissionId, cascadeDelete: true)
                .Index(t => t.SubmissionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageModels", "SubmissionId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.ImageModels", new[] { "SubmissionId" });
            DropTable("dbo.ImageModels");
        }
    }
}
