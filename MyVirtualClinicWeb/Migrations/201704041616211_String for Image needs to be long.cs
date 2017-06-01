namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringforImageneedstobelong : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageModels", "SubmissionId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.ImageModels", new[] { "SubmissionId" });
            DropPrimaryKey("dbo.ImageModels");
            AddColumn("dbo.ImageModels", "VirtualClinicSubmissionModel_SubmissionId", c => c.Int());
            AlterColumn("dbo.ImageModels", "SubmissionId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ImageModels", "Image", c => c.String());
            AddPrimaryKey("dbo.ImageModels", "SubmissionId");
            CreateIndex("dbo.ImageModels", "VirtualClinicSubmissionModel_SubmissionId");
            AddForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_SubmissionId", "dbo.VirtualClinicSubmissionModels", "SubmissionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_SubmissionId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.ImageModels", new[] { "VirtualClinicSubmissionModel_SubmissionId" });
            DropPrimaryKey("dbo.ImageModels");
            AlterColumn("dbo.ImageModels", "Image", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ImageModels", "SubmissionId", c => c.Int(nullable: false));
            DropColumn("dbo.ImageModels", "VirtualClinicSubmissionModel_SubmissionId");
            AddPrimaryKey("dbo.ImageModels", new[] { "SubmissionId", "Image" });
            CreateIndex("dbo.ImageModels", "SubmissionId");
            AddForeignKey("dbo.ImageModels", "SubmissionId", "dbo.VirtualClinicSubmissionModels", "SubmissionId", cascadeDelete: true);
        }
    }
}
