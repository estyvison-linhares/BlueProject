namespace BlueProject.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public string EntityName { get; }
        public object EntityId { get; }

        public NotFoundException(string entityName, object entityId)
            : base($"{entityName} with ID '{entityId}' not found.")
        {
            EntityName = entityName;
            EntityId = entityId;
        }
    }
}
