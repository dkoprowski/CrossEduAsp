namespace CrossEduAsp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gamePicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "PicturePath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "PicturePath");
        }
    }
}
