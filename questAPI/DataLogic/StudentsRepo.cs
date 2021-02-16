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

                SqlCommand cmd = new SqlCommand("SELECT s.STUDENT_ID, sl.SCHOOL_NAME, s.SCHOOL_ID, s.COMPETITION_ID, s.FIRST_NAME, s.LAST_NAME, l.SUBMITTED " +
                    "from Student as s INNER JOIN LiabilityForm as l ON s.STUDENT_ID = l.STUDENT_ID INNER JOIN SchoolList as sl ON sl.SCHOOLLIST_ID = s.SCHOOL_ID order by sl.SCHOOL_NAME, s.LAST_NAME;");
                cmd.Connection = connection;

                SqlDataReader reader = cmd.ExecuteReader();
                List<Student> results = new List<Student>();
                while (reader.Read())
                {

                    Student student = new Student()
                    {

                        StudentID = reader.GetInt64(0),
                        SchoolName = reader.GetString(1),
                        SchoolID = reader.GetInt16(2),
                        CompID = reader.GetInt16(3),
                        FirstName = reader.GetString(4),
                        LastName = reader.GetString(5),
                        Submitted = reader.GetBoolean(6),

                    };

                    results.Add(student);
                }
                connection.Close();
                return results;
            }
        }

        public IEnumerable<Student> GetStudentsBySchool(int schoolID)
        {
            using (SqlConnection connection = _database.GetConnection())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT s.STUDENT_ID, s.SCHOOL_ID, s.COMPETITION_ID, s.FIRST_NAME, s.LAST_NAME, l.SUBMITTED " +
                    "from Student as s INNER JOIN LiabilityForm as l ON s.STUDENT_ID = l.STUDENT_ID where s.SCHOOL_ID = @ID;");
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("ID", schoolID);

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
        public IEnumerable<Student> GetStudentsByForm()
        {
            using (SqlConnection connection = _database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT s.STUDENT_ID, s.SCHOOL_ID, s.COMPETITION_ID, s.FIRST_NAME, s.LAST_NAME, l.SUBMITTED " +
                        "from Student as s INNER JOIN LiabilityForm as l ON s.STUDENT_ID = l.STUDENT_ID where l.SUBMITTED = 1;");
                connection.Open();                                         
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
        public IEnumerable<Student> GetStudentsByNoForm()
        {
            using (SqlConnection connection = _database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT s.STUDENT_ID, s.SCHOOL_ID, s.COMPETITION_ID, s.FIRST_NAME, s.LAST_NAME, l.SUBMITTED " +
                        "from Student as s INNER JOIN LiabilityForm as l ON s.STUDENT_ID = l.STUDENT_ID where l.SUBMITTED = 0;");
                connection.Open();
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

        public void UpdateStudentFormFlag(int id, UpdateStudent updater)
        {
            using (SqlConnection connection = _database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UPDATE LiabilityForm SET SUBMITTED = @submitted WHERE STUDENT_ID = @id");

                cmd.Parameters.AddWithValue("submitted", updater.Submitted);
                cmd.Parameters.AddWithValue("id", id);

                connection.Open();
                cmd.Connection = connection;

                var recordsUpdated = cmd.ExecuteNonQuery();
                
                connection.Close();
                
            }
        }
    }
}
