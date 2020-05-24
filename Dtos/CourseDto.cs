using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using StudiumTracker.Models;

namespace StudiumTracker.Dtos
{
    public class CourseDto
    {
        public int Id { get; }

        public int LecturerId { get; set; }

        public int RoomId { get; set; }

        //public virtual ICollection<Student> Student { get; set; }

        public int SubjectId { get; set; }

        [Required]
        public DayOfWeek DayTakingPlace { get; set; }

        [Required]
        public TimeSpan StartingTime { get; set; }
    }
}
