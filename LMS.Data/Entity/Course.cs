using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.Entity
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Unique string key for the Course.
        /// </summary>
        [Required]
        [StringLength(10)]
        public string CourseCode { get; set; }

        [Required]
        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int Duration { get; set; }

        public  int DefaultPrice { get; set; }
    }
}
