using Study.HR.Core.Domain.Exceptions;
using System.Linq.Expressions;

namespace Study.HR.Core.Domain
{
    public class Entity<TId>
        where TId : struct
    {
        public TId Id { get; set; }


        protected void ThrowIf(bool condition, string message)
        {
            if (condition)
                throw new DomainException(message);
        }

    }

    public class Entity : Entity<int>
    {
    }

    
}