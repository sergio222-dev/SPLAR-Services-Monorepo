#region Imports

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SPLAR.Shared.Domain.Bus.Command;
using SPLAR.Shared.Domain.Json;

#endregion

namespace SPLAR.Wiki.Animes.Application.Create
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class AnimeCreateCommand : ICommand
    {
        #region Variables

        private string _sAnimeName;
        private string _sAnimeId;
        private string _sStudioId;

        #endregion

        #region Properties

        [JsonProperty] public string AnimeName => _sAnimeName;

        [JsonProperty] public string AnimeId => _sAnimeId;

        [JsonProperty] public string StudioId => _sStudioId;

        #endregion

        #region Constructs

        public AnimeCreateCommand(string sAnimeName, string sAnimeId, string sStudioId)
        {
            _sAnimeName = sAnimeName;
            _sAnimeId = sAnimeId;
            _sStudioId = sStudioId;
        }

        #endregion

        #region Statics Publics

        public static ICommand FromJson(string sJson)
        {
            var data = JObject.Parse(sJson);
            return new AnimeCreateCommand(
                data.GetString("AnimeName"),
                data.GetString("AnimeId"),
                data.GetString("StudioId")
            );
        }

        #endregion
    }
}