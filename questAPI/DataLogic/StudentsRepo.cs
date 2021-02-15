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

                SqlCommand cmd = new SqlCommand("SELECT STUDENT_ID, SCHOOL_ID, COMPETITION_ID, FIRST_NAME, LAST_NAME FROM dbo.Student");
                cmd.Connection = connection;

                SqlDataReader reader = cmd.ExecuteReader();
                List<Student> results = new List<Student>();
                while (reader.Read())
                {
                    Student student = new Student(reader.GetInt64(0), reader.GetInt16(1), reader.GetInt16(2), reader.GetString(3), reader.GetString(4));
                    results.Add(student);
                }
                connection.Close();
                return results;
            }
        }
    }
}
