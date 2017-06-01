namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addpersonattempt4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VirtualClinicSubmissionModels", "PersonModelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VirtualClinicSubmissionModels", "PersonModelId", c => c.Int(nullable: false));
        }
    }
}
