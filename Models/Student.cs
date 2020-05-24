using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudiumTracker.Models
{
    public class Student : IModelData
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Forename { get; set; }

        [Required]
        [MaxLength(250)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(25)]
        public string PhoneNumber { get; set; }

        [Required]
        public int CardId { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
