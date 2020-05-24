using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudiumTracker.Dtos
{
    public class LecturerDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Forename { get; set; }

        [Required]
        [MaxLength(250)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(25)]
        public string Phone { get; set; }
    }
}
