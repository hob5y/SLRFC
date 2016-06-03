namespace SLRFC.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedContactDetailsLink : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "ContactDetails_ContactDetailsId", "dbo.ContactDetails");
            DropForeignKey("dbo.Availabilities", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.Availabilities", "Player_MembershipId", "dbo.Members");
            DropIndex("dbo.Members", new[] { "ContactDetails_ContactDetailsId" });
            DropPrimaryKey("dbo.Availabilities");
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.ContactDetails");
            DropPrimaryKey("dbo.Members");
            AlterColumn("dbo.Availabilities", "AvailabilityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "EventId", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactDetails", "ContactDetailsId", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "MembershipId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Availabilities", "AvailabilityId");
            AddPrimaryKey("dbo.Events", "EventId");
            AddPrimaryKey("dbo.ContactDetails", "ContactDetailsId");
            AddPrimaryKey("dbo.Members", "MembershipId");
            AddForeignKey("dbo.Availabilities", "Event_EventId", "dbo.Events", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.Availabilities", "Player_MembershipId", "dbo.Members", "MembershipId");
            DropColumn("dbo.Members", "ContactDetails_ContactDetailsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "ContactDetails_ContactDetailsId", c => c.Int());
            DropForeignKey("dbo.Availabilities", "Player_MembershipId", "dbo.Members");
            DropForeignKey("dbo.Availabilities", "Event_EventId", "dbo.Events");
            DropPrimaryKey("dbo.Members");
            DropPrimaryKey("dbo.ContactDetails");
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.Availabilities");
            AlterColumn("dbo.Members", "MembershipId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ContactDetails", "ContactDetailsId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Events", "EventId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Availabilities", "AvailabilityId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Members", "MembershipId");
            AddPrimaryKey("dbo.ContactDetails", "ContactDetailsId");
            AddPrimaryKey("dbo.Events", "EventId");
            AddPrimaryKey("dbo.Availabilities", "AvailabilityId");
            CreateIndex("dbo.Members", "ContactDetails_ContactDetailsId");
            AddForeignKey("dbo.Availabilities", "Player_MembershipId", "dbo.Members", "MembershipId");
            AddForeignKey("dbo.Availabilities", "Event_EventId", "dbo.Events", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.Members", "ContactDetails_ContactDetailsId", "dbo.ContactDetails", "ContactDetailsId");
        }
    }
}
