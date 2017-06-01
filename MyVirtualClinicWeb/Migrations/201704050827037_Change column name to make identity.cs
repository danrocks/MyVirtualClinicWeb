namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changecolumnnametomakeidentity : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ImageModels");
            AddColumn("dbo.ImageModels", "ImageModelId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ImageModels", "ImageModelId");
            DropColumn("dbo.ImageModels", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageModels", "ImageId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ImageModels");
            DropColumn("dbo.ImageModels", "ImageModelId");
            AddPrimaryKey("dbo.ImageModels", "ImageId");
        }
    }
}
