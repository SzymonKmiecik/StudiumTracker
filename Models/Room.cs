using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiumTracker.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public int NumberOfSeats { get; set; }

        public bool SupportsProjector { get; set; }

    }
}
