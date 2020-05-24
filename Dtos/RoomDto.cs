using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudiumTracker.Dtos
{
    public class RoomDto
    {
        public int Id { get; }

        [Required]
        [MaxLength(250)]
        public string Location { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        [Required]
        public bool SupportsProjector { get; set; }
    }
}
