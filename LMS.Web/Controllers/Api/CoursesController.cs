using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LMS.Data;
using LMS.Data.Entity;

namespace LMS.Web.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private SchoolContext db = new SchoolContext();

        // GET: api/Courses
        public IQueryable<Course> GetCourse(int skip = 0, int take = 10)
        {
            return db.Course
                .OrderBy(f => f.Id)
                .Skip(skip)
                .Take(take)
                .Include(c => c.Topic);
        }

        // GET: api/Courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetCourse(int id)
        {
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseExists(int id)
        {
            return db.Course.Count(e => e.Id == id) > 0;
        }
    }
}