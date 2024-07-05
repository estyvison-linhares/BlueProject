namespace BlueProject.Domain.Exceptions
{
    public class InvalidFieldException : Exception
    {
        public string FieldName { get; }
        public object FieldValue { get; }
        
        public InvalidFieldException(string fieldName, object fieldValue, string message) : base(message) 
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
        }

        public InvalidFieldException(string fieldName, string message) : base(message)
        {
            FieldName = fieldName;
        }
    }
}
