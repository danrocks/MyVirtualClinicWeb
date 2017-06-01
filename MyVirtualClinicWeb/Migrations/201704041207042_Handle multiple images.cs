namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Handlemultipleimages : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VirtualClientSubmissionModels", "Img");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VirtualClientSubmissionModels", "Img", c => c.String(nullable: false));
        }
    }
}
