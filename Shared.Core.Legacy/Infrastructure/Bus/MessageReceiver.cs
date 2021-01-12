#region Imports

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ProtoBuf.WellKnownTypes;
using SPLAR.Shared.Contracts;
using SPLAR.Shared.Domain.Bus.Command;
using SPLAR.Shared.Services;

#endregion

namespace SPLAR.Shared.Infrastructure.Bus
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
            Console.WriteLine(oDataMessage.Data.Attributes);
            
            var sCommandName = oDataMessage.Data.Type;
            var sCommandData = oDataMessage.Data.Attributes;
            
            var oCommandType = _oCommandMapper.GetCommandTypeByName(sCommandName);
            var oCommand = _oCommandMapper.ToCommand(sCommandName, sCommandData);
            
            _oCommandBus.Dispatch(oCommand);

            return new ValueTask();
        }

        #endregion
    }
}