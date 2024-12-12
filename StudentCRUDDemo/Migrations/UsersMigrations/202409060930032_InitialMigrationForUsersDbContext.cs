namespace StudentCRUDDemo.Migrations.UsersMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationForUsersDbContext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "tblRole");
            RenameTable(name: "dbo.Users", newName: "tblUser");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tblUser", newName: "Users");
            RenameTable(name: "dbo.tblRole", newName: "Roles");
        }
    }
}
