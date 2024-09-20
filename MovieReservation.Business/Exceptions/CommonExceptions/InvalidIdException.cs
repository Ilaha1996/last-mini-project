namespace MovieReservation.Business.Exceptions.CommonExceptions
{
    public class InvalidIdException : Exception
    {
        public int StatusCode { get; set; } = 400; 
        public string? PropertyName { get; set; }
        public InvalidIdException() : base("Invalid ID provided")
        {
        }
        public InvalidIdException(string? message) : base(message)
        {
        }
        public InvalidIdException(int statusCode, string? propertyName, string? message): base(message ?? $"Invalid ID for property '{propertyName}'")
        {
            StatusCode = statusCode;
            PropertyName = propertyName;
        }
     
    }
}
