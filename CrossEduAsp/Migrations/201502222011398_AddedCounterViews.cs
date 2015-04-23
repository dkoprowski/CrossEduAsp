namespace CrossEduAsp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedCounterViews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "CounterViews", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "CounterViews");
        }
    }
}
