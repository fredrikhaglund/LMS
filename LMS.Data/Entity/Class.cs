using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.Entity
{

    public enum ClassStatus
    {
        Undefined = 0,
        Unlisted = 1,
        Published = 2,
        Cancelled = 3
    }
    /// <summary>
    /// One single instance of when a Course is given.
    /// </summary>
    public class Class
    {
        [Key]
        public int Id { get; set; }

        [EnumDataType(typeof(ClassStatus))]
        public ClassStatus Status { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        [Required]
        public int LocationId { get; set; }

        public Location Location { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Range(1,999)]
        public int MaxNumberOfParticipants { get; set; }

        public int? Price { get; set; }

    }
}
