using System;
namespace questAPI.Model
{
    public class Student
    {
        public long StudentID { get; set; }
        public int SchoolID { get; set; }
        public int CompID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Boolean Submitted { get; set; }

        public Student()
        {
           
        }
    }
}
