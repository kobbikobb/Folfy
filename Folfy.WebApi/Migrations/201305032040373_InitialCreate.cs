namespace Folfy.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Scorecards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Owner_Id = c.Int(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseHoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Par = c.Int(nullable: false),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Holes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        Scorecard_Id = c.Int(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scorecards", t => t.Scorecard_Id)
                .ForeignKey("dbo.Users", t => t.Player_Id)
                .Index(t => t.Scorecard_Id)
                .Index(t => t.Player_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Holes", new[] { "Player_Id" });
            DropIndex("dbo.Holes", new[] { "Scorecard_Id" });
            DropIndex("dbo.CourseHoles", new[] { "Course_Id" });
            DropIndex("dbo.Scorecards", new[] { "Course_Id" });
            DropIndex("dbo.Scorecards", new[] { "Owner_Id" });
            DropForeignKey("dbo.Holes", "Player_Id", "dbo.Users");
            DropForeignKey("dbo.Holes", "Scorecard_Id", "dbo.Scorecards");
            DropForeignKey("dbo.CourseHoles", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Scorecards", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Scorecards", "Owner_Id", "dbo.Users");
            DropTable("dbo.Holes");
            DropTable("dbo.CourseHoles");
            DropTable("dbo.Courses");
            DropTable("dbo.Users");
            DropTable("dbo.Scorecards");
        }
    }
}
