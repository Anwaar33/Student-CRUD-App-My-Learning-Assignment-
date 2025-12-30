namespace Student_CRUD_App.ExpHandler
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message, Exception innerException)
        : base(message, innerException)
        {
        }
    }
}
