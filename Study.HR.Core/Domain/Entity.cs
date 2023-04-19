namespace Study.HR.Core.Domain
{
    public class Entity<TId>
        where TId : struct
    {
        public TId Id { get; set; }
    }

    public class Entity : Entity<int>
    {
    }

    
}