#region Imports

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SPLAR.Shared.Domain.Bus.Command;

#endregion

namespace SPLAR.Wiki.Animes.Application.Delete
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AnimeDeleteCommand : ICommand
    {
        #region Variables

        private string _sAnimeName;

        #endregion

        #region Properties

        [JsonProperty] public string AnimeName => _sAnimeName;

        #endregion

        #region Constructs

        public AnimeDeleteCommand(string sAnimeName)
        {
            _sAnimeName = sAnimeName;
        }

        #endregion

        #region Statics Publics

        public static ICommand FromJson(string sJson)
        {
            var data = JObject.Parse(sJson);
            return new AnimeDeleteCommand(
                (string) data["AnimeName"]
            );
        }

        #endregion
    }
}