using LMS.Data.Entity;

namespace LMS.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SchoolContext : DbContext
    {
        // Your context has been configured to use a 'SchoolContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LMS.Data.SchoolContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SchoolContext' 
        // connection string in the application configuration file.
        public SchoolContext(): base("name=SchoolContext")
        {
        }


        public virtual DbSet<Class> Class { get; set; }

        public virtual DbSet<Course> Course { get; set; }

        public virtual DbSet<Enrollment> Enrollments { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

    }

}