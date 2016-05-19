using System.Text;
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

        static string RandomText(int minWords, int maxWords)
        {

            var words = new[]
            {
                "web", "business", "developer", "fundamental", "advanced", "C#",
                "mvc", "java", "integration", "UI", "UX", "CMS", "ASP.NET",
                "JavaScript", "front-end", "API", "cloud", "Azure", "intermediate", "nonsense"
            };

            var rand = new Random();
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();


            for (int w = 0; w < numWords; w++)
            {
                if (w > 0)
                {
                    result.Append(" ");
                }
                result.Append(words[rand.Next(words.Length)]);
            }

            return result.ToString();
        }

        const int NumberOfDummyCourses = 350;
        const int NumberOfClassesInAverage = 4;
        protected override void Seed(LMS.Data.SchoolContext context)
        {
            Random random = new Random();
            

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

            int classId = 0;

            for (int i = 0; i < NumberOfDummyCourses; i++)
            {
                int topicId = random.Next(1, 4);
                var duration = random.Next(1, 5);
                var price = duration*random.Next(7500, 15000);
                context.Course.AddOrUpdate(
                    c => c.Id,
                    new Course
                    {
                        Id = i,
                        CourseCode = $"{topicId}-{i:D4}",
                        Duration = duration,
                        DefaultPrice = price,
                        Name = RandomText(3, 7),
                        TopicId = topicId


                    });
                var classCount = random.Next(0, NumberOfClassesInAverage*2 - 1);
                for (int j = 0; j < classCount; j++)
                {
                    var startDate = DateTime.Now.Date.AddDays(-90).AddDays(random.Next(0, 365));
                    var statusRnd = random.Next(0, 99);
                    ClassStatus status = ClassStatus.Published;
                    if (statusRnd < 5)
                    {
                        status = ClassStatus.Cancelled;
                    } else if (statusRnd < 15)
                    {
                        status = ClassStatus.Unlisted;
                    }
                   context.Class.AddOrUpdate(
                       c => c.Id,
                       new Class()
                       {
                           Id = classId++,
                           CourseId = i,
                           LocationId = random.Next(1,5),
                           MaxNumberOfParticipants = random.Next(8,16),
                           StartDate = startDate,
                           Status = status

                       }); 
                }
            }


        }
    }
}
