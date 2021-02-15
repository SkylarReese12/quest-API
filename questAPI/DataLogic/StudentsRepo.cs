using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using questAPI.Model;

namespace questAPI.DataLogic
{
    public class StudentsRepo : IStudentsRepo
    {
        IDatabase _database;

        public StudentsRepo(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            using (SqlConnection connection = _database.GetConnection())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT s.STUDENT_ID, s.SCHOOL_ID, s.COMPETITION_ID, s.FIRST_NAME, s.LAST_NAME, l.SUBMITTED from Student as s INNER JOIN LiabilityForm as l ON s.STUDENT_ID = l.STUDENT_ID;");
                cmd.Connection = connection;

                SqlDataReader reader = cmd.ExecuteReader();
                List<Student> results = new List<Student>();
                while (reader.Read())
                {

                    Student student = new Student()
                    {

                        StudentID = reader.GetInt64(0),
                        SchoolID = reader.GetInt16(1),
                        CompID = reader.GetInt16(2),
                        FirstName = reader.GetString(3),
                        LastName = reader.GetString(4),
                        Submitted = reader.GetBoolean(5),

                    };

                    results.Add(student);
                }
                connection.Close();
                return results;
            }
        }
    }
}
