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

        public Student(long StudentID, int SchoolID, int CompID, string FirstName, string LastName)
        {
            this.StudentID = StudentID;
            this.SchoolID = SchoolID;
            this.CompID = CompID;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}
