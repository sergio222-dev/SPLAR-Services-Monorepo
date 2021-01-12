#region Imports

using System;
using MediatR;

#endregion

namespace SPLAR.Shared.Domain.Bus.Command
{
    public interface ICommand : IRequest
    {
        public static ICommand FromJson(string sJson)
        {
            throw new Exception("Method FromJson in ICommand Interface not implemented");
        }
    }
}