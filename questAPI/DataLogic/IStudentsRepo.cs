using System;
using System.Collections.Generic;
using questAPI.Model;

namespace questAPI.DataLogic
{
    public interface IStudentsRepo
    {
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> GetStudentsBySchool(int schoolID);
        IEnumerable<Student> GetStudentsByForm();
        IEnumerable<Student> GetStudentsByNoForm();
        void UpdateStudentFormFlag(int id, UpdateStudent updater);
    }
}
