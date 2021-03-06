﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudiumTracker.Models
{
    public class Course : IModelData
    {
        public int Id { get; set; }

        public int LecturerId { get; set; }
        [Required]
        public Lecturer Lecturer { get; set; }

        public int RoomId { get; set; }
        [Required]
        public virtual Room Room { get; set; }

        public int SubjectId { get; set; }
        [Required]
        public virtual Subject Subject { get; set; }

        [Required] 
        public DayOfWeek DayTakingPlace { get; set; }

        [Required]
        public TimeSpan StartingTime { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
