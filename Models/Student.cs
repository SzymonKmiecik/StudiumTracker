using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiumTracker.Models
{
    public class Student : IModelData
    {
        public int Id { get; set; }
        
        public string Forename { get; set; }

        public string Surename { get; set; }

        public string PhoneNumber { get; set; }

        public int CardId { get; set; }

        public DateTime BirthDate { get; set; }

    }
}
