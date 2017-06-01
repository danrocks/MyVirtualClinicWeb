namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addpersonattempt7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonModels", "VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels");
            DropForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.ImageModels", new[] { "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId" });
            DropIndex("dbo.PersonModels", new[] { "VirtualClinicSubmissionModelId" });
            DropColumn("dbo.ImageModels", "SubmissionId");
            RenameColumn(table: "dbo.ImageModels", name: "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId", newName: "SubmissionId");
            DropPrimaryKey("dbo.VirtualClinicSubmissionModels");
            AddColumn("dbo.PersonModels", "VirtualClinicSubmissionModel_SubmissionId", c => c.Int());
            AddColumn("dbo.VirtualClinicSubmissionModels", "SubmissionId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ImageModels", "SubmissionId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.VirtualClinicSubmissionModels", "SubmissionId");
            CreateIndex("dbo.ImageModels", "SubmissionId");
            CreateIndex("dbo.PersonModels", "VirtualClinicSubmissionModel_SubmissionId");
            AddForeignKey("dbo.PersonModels", "VirtualClinicSubmissionModel_SubmissionId", "dbo.VirtualClinicSubmissionModels", "SubmissionId");
            AddForeignKey("dbo.ImageModels", "SubmissionId", "dbo.VirtualClinicSubmissionModels", "SubmissionId", cascadeDelete: true);
            DropColumn("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ImageModels", "SubmissionId", "dbo.VirtualClinicSubmissionModels");
            DropForeignKey("dbo.PersonModels", "VirtualClinicSubmissionModel_SubmissionId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.PersonModels", new[] { "VirtualClinicSubmissionModel_SubmissionId" });
            DropIndex("dbo.ImageModels", new[] { "SubmissionId" });
            DropPrimaryKey("dbo.VirtualClinicSubmissionModels");
            AlterColumn("dbo.ImageModels", "SubmissionId", c => c.Int());
            DropColumn("dbo.VirtualClinicSubmissionModels", "SubmissionId");
            DropColumn("dbo.PersonModels", "VirtualClinicSubmissionModel_SubmissionId");
            AddPrimaryKey("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
            RenameColumn(table: "dbo.ImageModels", name: "SubmissionId", newName: "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId");
            AddColumn("dbo.ImageModels", "SubmissionId", c => c.Int(nullable: false));
            CreateIndex("dbo.PersonModels", "VirtualClinicSubmissionModelId");
            CreateIndex("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId");
            AddForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
            AddForeignKey("dbo.PersonModels", "VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId", cascadeDelete: true);
        }
    }
}
