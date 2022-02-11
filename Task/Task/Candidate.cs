using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.People
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string PositionDescription { get; set; }
        public int DesiredSalary { get; set; }
    }
}
