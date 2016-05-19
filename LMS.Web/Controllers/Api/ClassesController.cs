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
    public class ClassesController : ApiController
    {
        private SchoolContext db = new SchoolContext();

        // GET: api/Classes
        /// <summary>
        /// Get a list of all classes.
        /// </summary>
        /// <param name="courseCode"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IQueryable<Class> GetClass(string courseCode = "", int skip = 0, int take = 100)
        {
            IQueryable<Class> query = db.Class;

            if (!string.IsNullOrWhiteSpace(courseCode))
            {
                query = query.Where(f => f.Course.CourseCode == courseCode);
            }

            query = query.OrderBy(f => f.Id)
                .Skip(skip)
                .Take(take)
                .Include(c => c.Course)
                .Include(c => c.Location);

            return query;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}