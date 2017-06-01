namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addpersonattempt10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VirtualClinicSubmissionModels", "PersonModelId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VirtualClinicSubmissionModels", "PersonModelId");
        }
    }
}
