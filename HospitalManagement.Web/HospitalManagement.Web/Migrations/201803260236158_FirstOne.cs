namespace HospitalManagement.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Role = c.String(),
                        IsBlocked = c.String(),
                        IsAssigned = c.String(),
                        BuildingId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildingName = c.String(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BuildingName = c.String(),
                        BuildingId = c.Int(nullable: false),
                        FloorId = c.Int(nullable: false),
                        FloorNumber = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        updatedby = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Floors", t => t.FloorId, cascadeDelete: true)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId)
                .Index(t => t.FloorId);
            
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FloorNumber = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.ICUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ICUName = c.String(),
                        BuildingId = c.Int(nullable: false),
                        BuildingName = c.String(),
                        FloorId = c.Int(nullable: false),
                        FloorNumber = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Floors", t => t.FloorId, cascadeDelete: true)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId)
                .Index(t => t.FloorId);
            
            CreateTable(
                "dbo.Labs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        BuildingId = c.Int(nullable: false),
                        BuildingName = c.String(),
                        FloorId = c.Int(nullable: false),
                        FloorNumber = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Floors", t => t.FloorId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId)
                .Index(t => t.FloorId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        Description = c.String(),
                        FloorId = c.Int(nullable: false),
                        FloorNumber = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        Building_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Floors", t => t.FloorId)
                .ForeignKey("dbo.Buildings", t => t.Building_Id)
                .Index(t => t.FloorId)
                .Index(t => t.Building_Id);
            
            CreateTable(
                "dbo.OperationTheaters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        BuildingName = c.String(),
                        FloorId = c.Int(nullable: false),
                        FloorNumber = c.Int(nullable: false),
                        OperationDone = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Floors", t => t.FloorId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId)
                .Index(t => t.FloorId);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        IsEmpty = c.String(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        BuildingName = c.String(),
                        FloorId = c.Int(nullable: false),
                        FloorNumber = c.Int(nullable: false),
                        Where = c.String(),
                        WhereID = c.Int(nullable: false),
                        HasbeenUsed = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Floors", t => t.FloorId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId)
                .Index(t => t.FloorId);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        FloorId = c.Int(nullable: false),
                        FloorNumber = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DepartmentName = c.String(),
                        Updated = c.DateTime(nullable: false),
                        Updatedby = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Floors", t => t.FloorId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId)
                .Index(t => t.FloorId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNumber = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        BuildingName = c.String(),
                        Ticket_CounterId = c.Int(nullable: false),
                        Ticket_CounterNumber = c.Int(nullable: false),
                        PatientName = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DepartmentName = c.String(),
                        Price = c.Int(nullable: false),
                        IssuedTime = c.DateTime(nullable: false),
                        IssuedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ticket_Counter", t => t.Ticket_CounterId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId)
                .Index(t => t.Ticket_CounterId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Ticket_Counter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        BuildingName = c.String(),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(nullable: false),
                        age = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        Contact = c.String(),
                        ContactNo = c.String(),
                        ContactEmail = c.String(),
                        Departments = c.String(),
                        Degrees = c.String(),
                        SurgeryOrMedicine = c.String(),
                        JoinningDate = c.DateTime(nullable: false),
                        RetireDate = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        DoctorName = c.String(),
                        Schedule = c.String(),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.LabReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientName = c.String(),
                        TestName = c.String(),
                        Deatils = c.String(nullable: false),
                        Bill = c.Int(nullable: false),
                        AuthorisedDoctor = c.String(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Sex = c.String(nullable: false),
                        History = c.String(nullable: false),
                        Diagnosis = c.String(),
                        DiagnosisBy = c.String(),
                        AdmitDate = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        RefferedByDoctor = c.String(),
                        AssingedDoctor = c.String(),
                        MedicineHistory = c.String(),
                        MedicineGivenBy = c.String(),
                        SeatNumber = c.Int(nullable: false),
                        Where = c.String(),
                        WhereId = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staff_Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Contact = c.String(),
                        ContactNo = c.String(),
                        ContactEmail = c.String(),
                        Salary = c.Int(nullable: false),
                        Designation = c.String(nullable: false),
                        joinningDate = c.DateTime(nullable: false),
                        RetireDate = c.DateTime(nullable: false),
                        IssuedBy = c.String(nullable: false),
                        ImagePath = c.String(),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientName = c.String(),
                        Doctors_Checked = c.String(),
                        Medicine = c.String(),
                        Date = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Treatments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.LabReports", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.DoctorSchedules", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Wards", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Tickets", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Ticket_Counter", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Seats", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Rooms", "Building_Id", "dbo.Buildings");
            DropForeignKey("dbo.OperationTheaters", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Labs", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.ICUs", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Departments", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Tickets", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Tickets", "Ticket_CounterId", "dbo.Ticket_Counter");
            DropForeignKey("dbo.Wards", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.Wards", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Seats", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.Rooms", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.OperationTheaters", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.Labs", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.Labs", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.ICUs", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.Departments", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.Floors", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Treatments", new[] { "PatientId" });
            DropIndex("dbo.LabReports", new[] { "PatientId" });
            DropIndex("dbo.DoctorSchedules", new[] { "DoctorId" });
            DropIndex("dbo.Ticket_Counter", new[] { "BuildingId" });
            DropIndex("dbo.Tickets", new[] { "DepartmentId" });
            DropIndex("dbo.Tickets", new[] { "Ticket_CounterId" });
            DropIndex("dbo.Tickets", new[] { "BuildingId" });
            DropIndex("dbo.Wards", new[] { "DepartmentId" });
            DropIndex("dbo.Wards", new[] { "FloorId" });
            DropIndex("dbo.Wards", new[] { "BuildingId" });
            DropIndex("dbo.Seats", new[] { "FloorId" });
            DropIndex("dbo.Seats", new[] { "BuildingId" });
            DropIndex("dbo.OperationTheaters", new[] { "FloorId" });
            DropIndex("dbo.OperationTheaters", new[] { "BuildingId" });
            DropIndex("dbo.Rooms", new[] { "Building_Id" });
            DropIndex("dbo.Rooms", new[] { "FloorId" });
            DropIndex("dbo.Labs", new[] { "RoomId" });
            DropIndex("dbo.Labs", new[] { "FloorId" });
            DropIndex("dbo.Labs", new[] { "BuildingId" });
            DropIndex("dbo.ICUs", new[] { "FloorId" });
            DropIndex("dbo.ICUs", new[] { "BuildingId" });
            DropIndex("dbo.Floors", new[] { "BuildingId" });
            DropIndex("dbo.Departments", new[] { "FloorId" });
            DropIndex("dbo.Departments", new[] { "BuildingId" });
            DropTable("dbo.Treatments");
            DropTable("dbo.Staffs");
            DropTable("dbo.Staff_Category");
            DropTable("dbo.Patients");
            DropTable("dbo.LabReports");
            DropTable("dbo.DoctorSchedules");
            DropTable("dbo.Doctors");
            DropTable("dbo.Ticket_Counter");
            DropTable("dbo.Tickets");
            DropTable("dbo.Wards");
            DropTable("dbo.Seats");
            DropTable("dbo.OperationTheaters");
            DropTable("dbo.Rooms");
            DropTable("dbo.Labs");
            DropTable("dbo.ICUs");
            DropTable("dbo.Floors");
            DropTable("dbo.Departments");
            DropTable("dbo.Buildings");
            DropTable("dbo.AdminRoles");
        }
    }
}
