﻿namespace DataAccsesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_datecontact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactDate");
        }
    }
}