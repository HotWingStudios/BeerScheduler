namespace BeerScheduler.Accessors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipmentTypeAndSchedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        EquipmentTypeId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentTypeId);
            
            CreateTable(
                "dbo.EquipmentSchedules",
                c => new
                    {
                        EquipmentScheduleId = c.Long(nullable: false, identity: true),
                        EquipmentId = c.Long(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Equipment_EquipmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EquipmentScheduleId)
                .ForeignKey("dbo.Equipments", t => t.Equipment_EquipmentId)
                .Index(t => t.Equipment_EquipmentId);
            
            AddColumn("dbo.Equipments", "DateAquired", c => c.DateTime(nullable: false));
            AddColumn("dbo.Equipments", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Equipments", "EquipmentType_EquipmentTypeId", c => c.Long());
            CreateIndex("dbo.Equipments", "EquipmentType_EquipmentTypeId");
            AddForeignKey("dbo.Equipments", "EquipmentType_EquipmentTypeId", "dbo.EquipmentTypes", "EquipmentTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipmentSchedules", "Equipment_EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Equipments", "EquipmentType_EquipmentTypeId", "dbo.EquipmentTypes");
            DropIndex("dbo.EquipmentSchedules", new[] { "Equipment_EquipmentId" });
            DropIndex("dbo.Equipments", new[] { "EquipmentType_EquipmentTypeId" });
            DropColumn("dbo.Equipments", "EquipmentType_EquipmentTypeId");
            DropColumn("dbo.Equipments", "Deleted");
            DropColumn("dbo.Equipments", "DateAquired");
            DropTable("dbo.EquipmentSchedules");
            DropTable("dbo.EquipmentTypes");
        }
    }
}
