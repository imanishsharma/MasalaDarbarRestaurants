namespace MasalaDarbarRestaurants.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MasalaDarbarRestaurants.Models.MasalaDarbarDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MasalaDarbarRestaurants.Models.MasalaDarbarDbContext";
        }

        protected override void Seed(MasalaDarbarRestaurants.Models.MasalaDarbarDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.customerDetails.AddOrUpdate();
            context.branchesDetails.AddOrUpdate();
            context.reservationDetails.AddOrUpdate();
        }
    }
}
