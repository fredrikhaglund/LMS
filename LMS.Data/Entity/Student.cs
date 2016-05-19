using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.Entity
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]

        public string Firstname { get; set; }

        [Required]
        [StringLength(80)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(80)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(80)]
        public string Address1 { get; set; }

        [StringLength(80)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(10)]
        public string Zipcode { get; set; }

        [Required]
        [StringLength(40)]
        public string City { get; set; }

        [Required]
        [StringLength(40)]
        public string Country { get; set; }
    }
}
