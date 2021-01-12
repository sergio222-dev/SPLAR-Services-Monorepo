#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

#endregion

namespace SPAR.Shared.Domain.Bus.Command
{
    public class CommandMapper
    {
        #region Variables

        private IEnumerable<Type> _oLstCommandTypes;

        #endregion

        #region Constructs

        public CommandMapper(IEnumerable<Type> oLstCommandTypes)
        {
            _oLstCommandTypes = oLstCommandTypes;
        }

        #endregion

        #region Publics

        // public string ToJson<T>(T oCommand) where T : ICommand<>
        // {
        //     if (!Exists(oCommand.GetType().Name))
        //     {
        //         throw new Exception($"Command {typeof(T).Name} don't exists in Command list");
        //     }
        //
        //     return JsonSerializer.Serialize(oCommand);
        // }

        public Type GetCommandTypeByName(string sCommandName)
        {
            return _oLstCommandTypes.First(t => t.Name == sCommandName);
        }

        public ICommand ToCommand(string sCommandName, string sCommandData)
        {
            if (!Exists(sCommandName))
            {
                throw new Exception($"Command {sCommandName} don't exists in Command list");
            }

            var oCommandType = GetCommandTypeByName(sCommandName);
            // var oFromJsonMethod = GetFromJsonMethod(oCommandType);
            // var oCommand = oFromJsonMethod.Invoke(null, new object[] { oCommandType, sCommandData});

            var oCommand = ICommand.FromJson(oCommandType, sCommandData);
            
            return (ICommand) oCommand;
        }

        #endregion

        #region Privates

        private bool Exists(string sName)
        {
            return _oLstCommandTypes.Any(t => t.Name == sName);
        }

        private MethodInfo GetFromJsonMethod(Type oCommandType)
        {
            var oMethodInfo = oCommandType.GetMethod("FromJson");

            if (oMethodInfo == null)
            {
                throw new Exception($"Method FromJson not presented in type {oCommandType.Name}");
            }

            return oMethodInfo;
        }

        #endregion
    }
}