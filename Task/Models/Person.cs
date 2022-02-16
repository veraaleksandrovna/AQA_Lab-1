using System;

namespace Task2
{
    public class Person
    {
        public string FirstName { get;}
        public string LastName { get;}
        public DateTime DateOfBirth { get;}
        public bool Driver { get;}

        public Person(string fname,string lname,DateTime dateOfBirth,bool isDriver)
        {
            FirstName = fname;
            LastName = lname;
            DateOfBirth = dateOfBirth;
            Driver = isDriver;
        }
    }
}