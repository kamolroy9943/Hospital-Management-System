namespace HospitalManagement.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTwo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WhatFor = c.String(),
                        Description = c.String(),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        Amount = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        PatientName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientName = c.String(),
                        PayerName = c.String(),
                        Paid = c.String(),
                        Due = c.String(),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Bills", "PatientId", "dbo.Patients");
            DropIndex("dbo.Payments", new[] { "PatientId" });
            DropIndex("dbo.Bills", new[] { "PatientId" });
            DropTable("dbo.Payments");
            DropTable("dbo.Bills");
        }
    }
}
