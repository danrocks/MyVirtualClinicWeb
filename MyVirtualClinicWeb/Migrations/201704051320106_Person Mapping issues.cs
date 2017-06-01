namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonMappingissues : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId", "dbo.PersonModels");
            DropForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.VirtualClinicSubmissionModels", new[] { "VirtualClinicSubmissionModelId" });
            DropPrimaryKey("dbo.VirtualClinicSubmissionModels");
            AlterColumn("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
            CreateIndex("dbo.PersonModels", "VirtualClinicSubmissionModelId");
            AddForeignKey("dbo.PersonModels", "VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId", cascadeDelete: true);
            AddForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
            DropColumn("dbo.VirtualClinicSubmissionModels", "PersonModelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VirtualClinicSubmissionModels", "PersonModelId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels");
            DropForeignKey("dbo.PersonModels", "VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.PersonModels", new[] { "VirtualClinicSubmissionModelId" });
            DropPrimaryKey("dbo.VirtualClinicSubmissionModels");
            AlterColumn("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
            CreateIndex("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
            AddForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
            AddForeignKey("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId", "dbo.PersonModels", "PersonModelId");
        }
    }
}
