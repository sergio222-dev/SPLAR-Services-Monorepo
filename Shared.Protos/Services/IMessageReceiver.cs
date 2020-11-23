#region Imports

using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using ProtoBuf.WellKnownTypes;
using SPLAR.Shared.Contracts;

#endregion

namespace SPLAR.Shared.Services
{
    [ServiceContract(Name = "MessageReceiver")]
    public interface IMessageReceiver
    {
        ValueTask Message(DataMessage data);
    }
}