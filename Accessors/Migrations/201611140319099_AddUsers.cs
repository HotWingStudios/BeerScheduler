namespace BeerScheduler.Accessors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        LockoutEndDateUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        AccessFailedCount = c.Int(nullable: false),
                        Admin = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Activated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
