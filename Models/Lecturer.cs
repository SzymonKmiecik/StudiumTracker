using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudiumTracker.Models
{
    public class Lecturer : IModelData
    {
        [Key]
        public int  Id { get; set; }

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
        public int EmployeeId { get; set; }

    }
}
