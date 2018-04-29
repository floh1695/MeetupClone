namespace MeetupClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendeeID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttendeeID, t.EventID })
                .ForeignKey("dbo.Attendees", t => t.AttendeeID, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .Index(t => t.AttendeeID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityID = c.Int(),
                        Title = c.String(),
                        Tagline = c.String(),
                        LongDescription = c.String(),
                        Address = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        MinimumAge = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "EventID", "dbo.Events");
            DropForeignKey("dbo.Events", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Attendances", "AttendeeID", "dbo.Attendees");
            DropIndex("dbo.Events", new[] { "CityID" });
            DropIndex("dbo.Attendances", new[] { "EventID" });
            DropIndex("dbo.Attendances", new[] { "AttendeeID" });
            DropTable("dbo.Cities");
            DropTable("dbo.Events");
            DropTable("dbo.Attendees");
            DropTable("dbo.Attendances");
        }
    }
}
