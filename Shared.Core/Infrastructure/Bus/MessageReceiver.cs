#region Imports

using System;
using System.Threading.Tasks;
using SPAR.Shared.Domain.Bus.Command;
using SPLAR.Shared.Contracts;
using SPLAR.Shared.Services;

#endregion

namespace Infrastructure.Bus
{
    public class MessageReceiver : IMessageReceiver
    {
        #region Variables

        private ICommandBus _oCommandBus;
        private CommandMapper _oCommandMapper;

        #endregion

        #region Constructs

        public MessageReceiver(ICommandBus oCommandBus, CommandMapper oCommandMapper)
        {
            _oCommandBus = oCommandBus;
            _oCommandMapper = oCommandMapper;
        }

        #endregion

        #region Methods

        ValueTask IMessageReceiver.Message(DataMessage oDataMessage)
        {
            var sCommandName = oDataMessage.Data.Type;
            var sCommandData = oDataMessage.Data.Attributes;
            
            // var oCommandType = _oCommandMapper.GetCommandTypeByName(sCommandName);
            var oCommand = _oCommandMapper.ToCommand(sCommandName, sCommandData);
            
            _oCommandBus.Dispatch(oCommand);

            return new ValueTask();
        }

        #endregion
    }
}