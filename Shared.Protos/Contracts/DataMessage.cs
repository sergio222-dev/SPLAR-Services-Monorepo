#region Imports

using ProtoBuf;

#endregion

namespace SPLAR.Shared.Contracts
{
    [ProtoContract]
    public class DataMessage
    {
        [ProtoMember(1)] public Data Data { get; set; }
        
        [ProtoMember(2)] public Meta Meta { get; set; }
    }

    [ProtoContract]
    public class Data
    {
        [ProtoMember(1)] public string Type { get; set; }
        
        [ProtoMember(2)] public string Id { get; set; }
        
        [ProtoMember(3)] public string Attributes { get; set; }
    }

    [ProtoContract]
    public class Meta
    {
        [ProtoMember(1)] public string Bus { get; set; }
    }
}