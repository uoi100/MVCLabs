namespace MVCLab04.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseRegistrations",
                c => new
                    {
                        CourseRegistrationID = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        Course_CourseID = c.String(maxLength: 100),
                        Student_StudentID = c.String(maxLength: 9),
                    })
                .PrimaryKey(t => t.CourseRegistrationID)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID)
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .Index(t => t.Course_CourseID)
                .Index(t => t.Student_StudentID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.String(nullable: false, maxLength: 100),
                        CourseName = c.String(nullable: false, maxLength: 100),
                        CourseCredit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 9),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Birthday = c.DateTime(nullable: false),
                        Program_ProgramID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Programs", t => t.Program_ProgramID)
                .Index(t => t.Program_ProgramID);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramID = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ProgramID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Program_ProgramID", "dbo.Programs");
            DropForeignKey("dbo.CourseRegistrations", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseRegistrations", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "Program_ProgramID" });
            DropIndex("dbo.CourseRegistrations", new[] { "Student_StudentID" });
            DropIndex("dbo.CourseRegistrations", new[] { "Course_CourseID" });
            DropTable("dbo.Programs");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseRegistrations");
        }
    }
}
