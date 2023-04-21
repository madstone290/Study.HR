using MediatR;

namespace Study.HR.Core.Application.Base
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }

    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
         where TQuery : IQuery<TResult>
    {
        public abstract Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
