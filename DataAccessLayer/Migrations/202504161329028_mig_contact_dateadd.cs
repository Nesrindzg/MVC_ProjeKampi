﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contact_dateadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "MessageDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "MessageDate");
        }
    }
}
