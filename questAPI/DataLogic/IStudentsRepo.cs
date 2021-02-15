using System;
using System.Collections.Generic;
using questAPI.Model;

namespace questAPI.DataLogic
{
    public interface IStudentsRepo
    {
        IEnumerable<Student> GetAllStudents();
    }
}
