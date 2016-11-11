namespace BeerScheduler.Accessors.Migrations
{
    using DataContracts;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.ContextKey = "BeerScheduler.Accessors.DatabaseContext";
        }

        protected override void Seed(BeerScheduler.Accessors.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.EquipmentTypes.AddOrUpdate(x => x.EquipmentTypeId, new EquipmentType() { EquipmentTypeId = 1, Name = "Not Specified" });
        }
    }
}
