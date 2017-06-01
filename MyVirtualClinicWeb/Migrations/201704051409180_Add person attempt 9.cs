namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addpersonattempt9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonModels", "VirtualClinicSubmissionModel_SubmissionId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.PersonModels", new[] { "VirtualClinicSubmissionModel_SubmissionId" });
            RenameColumn(table: "dbo.PersonModels", name: "VirtualClinicSubmissionModel_SubmissionId", newName: "SubmissionId");
            AlterColumn("dbo.PersonModels", "SubmissionId", c => c.Int(nullable: false));
            CreateIndex("dbo.PersonModels", "SubmissionId");
            AddForeignKey("dbo.PersonModels", "SubmissionId", "dbo.VirtualClinicSubmissionModels", "SubmissionId", cascadeDelete: true);
            DropColumn("dbo.PersonModels", "VirtualClinicSubmissionModelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonModels", "VirtualClinicSubmissionModelId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PersonModels", "SubmissionId", "dbo.VirtualClinicSubmissionModels");
            DropIndex("dbo.PersonModels", new[] { "SubmissionId" });
            AlterColumn("dbo.PersonModels", "SubmissionId", c => c.Int());
            RenameColumn(table: "dbo.PersonModels", name: "SubmissionId", newName: "VirtualClinicSubmissionModel_SubmissionId");
            CreateIndex("dbo.PersonModels", "VirtualClinicSubmissionModel_SubmissionId");
            AddForeignKey("dbo.PersonModels", "VirtualClinicSubmissionModel_SubmissionId", "dbo.VirtualClinicSubmissionModels", "SubmissionId");
        }
    }
}
