namespace StudentCRUDDemo.Migrations.StudentsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationForUsersDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblStudents",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblStudents");
        }
    }
}
