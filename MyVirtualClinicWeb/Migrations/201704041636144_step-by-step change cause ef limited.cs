namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stepbystepchangecauseeflimited : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_SubmissionId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.ImageModels", new[] { "VirtualClinicSubmissionModel_SubmissionId" });
            DropPrimaryKey("dbo.ImageModels");
            DropColumn("dbo.ImageModels", "SubmissionId");
            RenameColumn(table: "dbo.ImageModels", name: "VirtualClinicSubmissionModel_SubmissionId", newName: "SubmissionId");
            
            AlterColumn("dbo.ImageModels", "SubmissionId", c => c.Int(nullable: false));
            AlterColumn("dbo.ImageModels", "ImageId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ImageModels", "SubmissionId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ImageModels", "ImageId");
            CreateIndex("dbo.ImageModels", "SubmissionId");
            AddForeignKey("dbo.ImageModels", "SubmissionId", "dbo.VirtualClinicSubmissionModels", "SubmissionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageModels", "SubmissionId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.ImageModels", new[] { "SubmissionId" });
            DropPrimaryKey("dbo.ImageModels");
            AlterColumn("dbo.ImageModels", "SubmissionId", c => c.Int());
            AlterColumn("dbo.ImageModels", "ImageId", c => c.Int(nullable: false));
            AlterColumn("dbo.ImageModels", "SubmissionId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ImageModels", "SubmissionId");
            RenameColumn(table: "dbo.ImageModels", name: "SubmissionId", newName: "VirtualClinicSubmissionModel_SubmissionId");
            AddColumn("dbo.ImageModels", "SubmissionId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.ImageModels", "VirtualClinicSubmissionModel_SubmissionId");
            AddForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_SubmissionId", "dbo.VirtualClinicSubmissionModels", "SubmissionId");
        }
    }
}
