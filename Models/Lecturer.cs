using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiumTracker.Models
{
    public class Lecturer : IModelData
    {
        public int  Id { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public int EmployeeId { get; set; }

    }
}
