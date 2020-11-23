#region Imports

using MediatR;
using SPLAR.Shared.Domain.Bus.Command;

#endregion

namespace SPLAR.Shared.Infrastructure.Bus.Command
{
    public class MediatorCommandBus : Mediator, ICommandBus
    {
        #region Constructs

        public MediatorCommandBus(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        #endregion

        #region Publics Methods

        public void Dispatch(ICommand oCommand)
        {
            Send((IRequest) oCommand);
        }

        #endregion
    }
}