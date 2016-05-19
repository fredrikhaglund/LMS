using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.Entity
{
    public enum EnrollmentStatus
    {
        Undefined = 0,
        Pending = 1,
        Approved = 2,
        WaitingList = 3,
        Cancelled = 4
    }

    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClassId { get; set; }

        public Class Class { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Required]
        [EnumDataType(typeof(EnrollmentStatus))]
        public EnrollmentStatus Status { get; set; }
    }
}
