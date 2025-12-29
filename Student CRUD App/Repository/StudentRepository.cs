using Microsoft.Data.SqlClient;
using System.Data;
using Student_CRUD_App.StudentModel;
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

        // SELECT
        public List<Student> GetAllStudents()
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

        // UPDATE
        public void UpdateStudent(Student student)
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

        // DELETE
        public void DeleteStudent(int studentId)
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("sp_Student_CRUD", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "DELETE");
            cmd.Parameters.AddWithValue("@StudentId", studentId);

            con.Open();
            cmd.ExecuteNonQuery();
        }





    }
}
