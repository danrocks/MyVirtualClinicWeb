namespace MyVirtualClinicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stilltryngtosaveimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageModels", "ImageId", c => c.Int(nullable: false));
            AlterColumn("dbo.ImageModels", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImageModels", "Image", c => c.String());
            DropColumn("dbo.ImageModels", "ImageId");
        }
    }
}
