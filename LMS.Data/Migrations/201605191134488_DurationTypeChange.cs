namespace LMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DurationTypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Duration", c => c.String());
        }
    }
}
