#region Imports

using Newtonsoft.Json.Linq;

#endregion

namespace Domain.Json
{
    public static class JsonPropertyString
    {
        public static string GetString(this JObject data, string sName)
        {
            return (string) data[sName];
        }
    }
}