using LMS.Data.Entity;

namespace LMS.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LMS.Data.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LMS.Data.SchoolContext context)
        {

            context.Locations.AddOrUpdate(
                c => c.Id,
                new Location { Id = 1, Name = "Stockholm"},
                new Location { Id = 2, Name = "Malmö"},
                new Location { Id = 3, Name = "Göteborg"},
                new Location { Id = 4, Name = "Linköping" },
                new Location { Id = 5, Name = "Umeå" });

            context.Topics.AddOrUpdate(
                c => c.Id,
                new Topic {Id = 1, Name = "DotNet"},
                new Topic {Id = 2, Name = "Java"},
                new Topic {Id = 3, Name = "Scrum"},
                new Topic {Id = 4, Name = "Webbutveckling"});

        }
    }
}
