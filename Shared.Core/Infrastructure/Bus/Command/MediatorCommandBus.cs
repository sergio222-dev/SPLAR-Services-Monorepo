using System;
using SPAR.Shared.Domain.Bus.Command;
using MediatR;

namespace SPAR.Shared.Infrastructure.Bus.Command
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
            Send(oCommand);
        }

        #endregion
    }
}