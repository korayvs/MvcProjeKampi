namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_headingstatusadd_fixcontentstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HeadingStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contents", "ContentStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contents", "ContentValues");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "ContentValues", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contents", "ContentStatus");
            DropColumn("dbo.Headings", "HeadingStatus");
        }
    }
}
