using Microsoft.Data.SqlClient;
using Student_CRUD_App.ExpHandler;
using Student_CRUD_App.StudentModel;
using System.Data;
namespace Student_CRUD_App.Repository
{
    public class StudentRepository
    {
        
        private readonly string _connectionString;
        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // INSERT into Student
        public void InsertStudent(Student student)
        {
            try
            {
                using SqlConnection con = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("sp_Student_CRUD", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Class", student.Class);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Database error while inserting student.", ex);
            }

        }

        // SELECT
        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = new();
                using SqlConnection con = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("sp_Student_CRUD", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SELECT");

                con.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Class = reader["Class"].ToString()
                    });
                }
                return students;
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Database error while retrieving students.", ex);
            }

        }

        // UPDATE
        public void UpdateStudent(Student student)
        {
            try
            {
                using SqlConnection con = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("sp_Student_CRUD", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Class", student.Class);

                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Database error while updating student.", ex);
            }

        }

        // DELETE
        public void DeleteStudent(int studentId)
        {
            try
            {
                using SqlConnection con = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("sp_Student_CRUD", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@StudentId", studentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Database error while deleting student.", ex);
            }

        }
    }
}
