#region Imports

using System;
using System.Collections.Generic;
using Domain.Json;
using MediatR;
using Newtonsoft.Json.Linq;
using SPLAR.Wiki.Animes.Application.Create;

#endregion

namespace SPAR.Shared.Domain.Bus.Command
{
    public interface ICommand : IRequest
    {
        public static ICommand FromJson(Type oCommandType, string sJson)
        {
            var data = JObject.Parse(sJson);

            var command = (ICommand)Activator.CreateInstance(oCommandType, true);
            
            foreach (var keyValuePair in data)
            {
                oCommandType.GetProperty(keyValuePair.Key)?
                    .SetValue(command, keyValuePair.Value.ToString());
            }

            return command;
        }
    }
}