namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludePersoninvirtclinicsubmission : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageModels", "SubmissionId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.ImageModels", new[] { "SubmissionId" });
            DropPrimaryKey("dbo.VirtualClinicSubmissionModels");
            CreateTable(
                "dbo.PersonModels",
                c => new
                    {
                        PersonModelId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Surname = c.String(),
                        Dob = c.DateTime(nullable: false),
                        VirtualClinicSubmissionModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonModelId);
            
            AddColumn("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId", c => c.Int());
            AddColumn("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId", c => c.Int(nullable: false));
            AddColumn("dbo.VirtualClinicSubmissionModels", "PersonModelId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
            CreateIndex("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId");
            CreateIndex("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
            AddForeignKey("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId", "dbo.PersonModels", "PersonModelId");
            AddForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
            DropColumn("dbo.VirtualClinicSubmissionModels", "SubmissionId");
            DropColumn("dbo.VirtualClinicSubmissionModels", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VirtualClinicSubmissionModels", "PersonId", c => c.Int(nullable: false));
            AddColumn("dbo.VirtualClinicSubmissionModels", "SubmissionId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId", "dbo.VirtualClinicSubmissionModels");
            DropForeignKey("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId", "dbo.PersonModels");
            DropIndex("dbo.VirtualClinicSubmissionModels", new[] { "VirtualClinicSubmissionModelId" });
            DropIndex("dbo.ImageModels", new[] { "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId" });
            DropPrimaryKey("dbo.VirtualClinicSubmissionModels");
            DropColumn("dbo.VirtualClinicSubmissionModels", "PersonModelId");
            DropColumn("dbo.VirtualClinicSubmissionModels", "VirtualClinicSubmissionModelId");
            DropColumn("dbo.ImageModels", "VirtualClinicSubmissionModel_VirtualClinicSubmissionModelId");
            DropTable("dbo.PersonModels");
            AddPrimaryKey("dbo.VirtualClinicSubmissionModels", "SubmissionId");
            CreateIndex("dbo.ImageModels", "SubmissionId");
            AddForeignKey("dbo.ImageModels", "SubmissionId", "dbo.VirtualClinicSubmissionModels", "SubmissionId", cascadeDelete: true);
        }
    }
}
