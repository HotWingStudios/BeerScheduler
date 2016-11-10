namespace BeerScheduler.Accessors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipmentTypeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Equipments", "EquipmentType_EquipmentTypeId", "dbo.EquipmentTypes");
            DropForeignKey("dbo.EquipmentSchedules", "Equipment_EquipmentId", "dbo.Equipments");
            DropIndex("dbo.Equipments", new[] { "EquipmentType_EquipmentTypeId" });
            DropIndex("dbo.EquipmentSchedules", new[] { "Equipment_EquipmentId" });
            DropColumn("dbo.EquipmentSchedules", "EquipmentId");
            RenameColumn(table: "dbo.Equipments", name: "EquipmentType_EquipmentTypeId", newName: "EquipmentTypeId");
            RenameColumn(table: "dbo.EquipmentSchedules", name: "Equipment_EquipmentId", newName: "EquipmentId");
            DropPrimaryKey("dbo.Equipments");
            AlterColumn("dbo.Equipments", "EquipmentId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Equipments", "EquipmentTypeId", c => c.Long(nullable: false));
            AlterColumn("dbo.EquipmentSchedules", "EquipmentId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Equipments", "EquipmentId");
            CreateIndex("dbo.Equipments", "EquipmentTypeId");
            CreateIndex("dbo.EquipmentSchedules", "EquipmentId");
            AddForeignKey("dbo.Equipments", "EquipmentTypeId", "dbo.EquipmentTypes", "EquipmentTypeId", cascadeDelete: true);
            AddForeignKey("dbo.EquipmentSchedules", "EquipmentId", "dbo.Equipments", "EquipmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipmentSchedules", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Equipments", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropIndex("dbo.EquipmentSchedules", new[] { "EquipmentId" });
            DropIndex("dbo.Equipments", new[] { "EquipmentTypeId" });
            DropPrimaryKey("dbo.Equipments");
            AlterColumn("dbo.EquipmentSchedules", "EquipmentId", c => c.Int());
            AlterColumn("dbo.Equipments", "EquipmentTypeId", c => c.Long());
            AlterColumn("dbo.Equipments", "EquipmentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Equipments", "EquipmentId");
            RenameColumn(table: "dbo.EquipmentSchedules", name: "EquipmentId", newName: "Equipment_EquipmentId");
            RenameColumn(table: "dbo.Equipments", name: "EquipmentTypeId", newName: "EquipmentType_EquipmentTypeId");
            AddColumn("dbo.EquipmentSchedules", "EquipmentId", c => c.Long(nullable: false));
            CreateIndex("dbo.EquipmentSchedules", "Equipment_EquipmentId");
            CreateIndex("dbo.Equipments", "EquipmentType_EquipmentTypeId");
            AddForeignKey("dbo.EquipmentSchedules", "Equipment_EquipmentId", "dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Equipments", "EquipmentType_EquipmentTypeId", "dbo.EquipmentTypes", "EquipmentTypeId");
        }
    }
}
