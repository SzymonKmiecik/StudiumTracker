using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudiumTracker.Dtos
{
    public class SubjectDto
    {
        public int Id { get; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Points { get; set; }
    }
}
