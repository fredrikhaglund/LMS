namespace LMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        MaxNumberOfParticipants = c.Int(nullable: false),
                        Price = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false, maxLength: 10),
                        TopicId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Duration = c.String(),
                        DefaultPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 80),
                        Lastname = c.String(nullable: false, maxLength: 80),
                        Email = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(maxLength: 20),
                        CompanyName = c.String(maxLength: 80),
                        Address1 = c.String(nullable: false, maxLength: 80),
                        Address2 = c.String(maxLength: 80),
                        Zipcode = c.String(nullable: false, maxLength: 10),
                        City = c.String(nullable: false, maxLength: 40),
                        Country = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Classes", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "TopicId", "dbo.Topics");
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Enrollments", new[] { "ClassId" });
            DropIndex("dbo.Courses", new[] { "TopicId" });
            DropIndex("dbo.Classes", new[] { "LocationId" });
            DropIndex("dbo.Classes", new[] { "CourseId" });
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Locations");
            DropTable("dbo.Topics");
            DropTable("dbo.Courses");
            DropTable("dbo.Classes");
        }
    }
}
