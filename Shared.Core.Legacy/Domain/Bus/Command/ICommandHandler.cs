#region Imports

using MediatR;

#endregion

namespace SPLAR.Shared.Domain.Bus.Command
{
    public interface ICommandHandler<TRequest> : IRequestHandler<TRequest> where TRequest : IRequest<Unit>
    {
    }
}