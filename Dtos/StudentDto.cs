using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StudiumTracker.Models;

namespace StudiumTracker.Dtos
{

    public class StudentDto
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Forename { get; set; }

        [Required]
        [MaxLength(250)]
        public string Surename { get; set; }

        [Required]
        [MaxLength(25)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

    }
}
