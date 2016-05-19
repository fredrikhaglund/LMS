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
    public class EnrollmentsController : ApiController
    {
        private SchoolContext db = new SchoolContext();

        //// GET: api/Enrollments
        //public IQueryable<Enrollment> GetEnrollments()
        //{
        //    return db.Enrollments;
        //}

        //// GET: api/Enrollments/5
        //[ResponseType(typeof(Enrollment))]
        //public IHttpActionResult GetEnrollment(int id)
        //{
        //    Enrollment enrollment = db.Enrollments.Find(id);
        //    if (enrollment == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(enrollment);
        //}

        //// PUT: api/Enrollments/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutEnrollment(int id, Enrollment enrollment)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != enrollment.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(enrollment).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EnrollmentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Enrollments
        /// <summary>
        /// Post information about a student as a json object and specify classId to enroll a student to a class.
        /// If you specify a courseCode or courseId the student will be added to the list of intrested that will be
        /// notified about upcoming classes.
        /// If niether courseCode, courseId or classId is present the student will just be added to the database but
        /// no releations to classes or courses are made.
        /// </summary>
        /// <param name="student">Student object. If Id is zero a new student will be created.</param>
        /// <param name="courseCode">Text code for a course to register interest. Not needed when classId is present.</param>
        /// <param name="courseId">Numerical Id for a course to register interest. Not needed when classId is present.</param>
        /// <param name="classId">Numerical Id for a class.</param>
        /// <returns></returns>
        [ResponseType(typeof(Enrollment))]
        public IHttpActionResult PostEnrollment( Student student, string courseCode = "", int courseId = 0, int classId = 0)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.Enrollments.Add(enrollment);
            //db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);

            //return CreatedAtRoute("DefaultApi", new { id = 0 }, enrollment);
        }

        //// DELETE: api/Enrollments/5
        //[ResponseType(typeof(Enrollment))]
        //public IHttpActionResult DeleteEnrollment(int id)
        //{
        //    Enrollment enrollment = db.Enrollments.Find(id);
        //    if (enrollment == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Enrollments.Remove(enrollment);
        //    db.SaveChanges();

        //    return Ok(enrollment);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnrollmentExists(int id)
        {
            return db.Enrollments.Count(e => e.Id == id) > 0;
        }
    }
}