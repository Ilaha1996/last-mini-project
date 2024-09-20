namespace MovieReservation.Business.Exceptions.CommonExceptions
{
    public class EntityNotFoundException: Exception
    {
        public int StatusCode { get; set; } = 404;
        public string PropertyName { get; set; }
        public EntityNotFoundException(): base("Entity not found")
        {

        }
        public EntityNotFoundException(string? message) : base(message)
        {

        }

        public EntityNotFoundException(int statusCode, string? propertyName, string? message): base(message ?? $"Entity '{propertyName}' not found")
        {
            StatusCode = statusCode;
            PropertyName = propertyName;
        }
    }
}
