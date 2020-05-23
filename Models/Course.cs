using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiumTracker.Models
{
    public class Course
    {
        public int Id { get; set; }

        public Lecturer Lecturer { get; set; }

        public Student Student { get; set; }

        public Room Room { get; set; }

        public Subject Subject { get; set; }

    }
}
