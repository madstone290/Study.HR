using MediatR;

namespace Study.HR.Core.Application.Base
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand
    {

    }

    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {

    }

    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
          where TCommand : ICommand
    {
        public abstract Task Handle(TCommand command, CancellationToken cancellationToken);
    }

    public abstract class CommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
                where TCommand : ICommand<TResult>
    {
        public abstract Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
