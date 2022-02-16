using System;
using System.Collections.Generic;

namespace Task2
{
    public class Driver
    {
        public DateTime DateDriverLicence { get; set; }
        public Guid ID { get;}
        public List<Vehicle> _vehicles { get; set; }

        public Driver()
        {
            ID = Guid.NewGuid();
            DateDriverLicence = DateTime.Now.AddYears(-1);
            _vehicles = new List<Vehicle>();
        }
        
        public Driver(DateTime dateDriverLicence,List<Vehicle> vehicles)
        {
            ID = Guid.NewGuid();
            DateDriverLicence = dateDriverLicence;
            _vehicles.AddRange(vehicles);
        }
    }
}