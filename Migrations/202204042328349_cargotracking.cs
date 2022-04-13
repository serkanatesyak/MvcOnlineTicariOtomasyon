﻿namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargotracking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailsID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 300, unicode: false),
                        TrackingCode = c.String(maxLength: 10, unicode: false),
                        Employee = c.String(maxLength: 20, unicode: false),
                        DeliveryPerson = c.String(maxLength: 20, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailsID);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        CargoTrackingID = c.Int(nullable: false, identity: true),
                        TrackingCode = c.String(maxLength: 10, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrackingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.CargoDetails");
        }
    }
}
