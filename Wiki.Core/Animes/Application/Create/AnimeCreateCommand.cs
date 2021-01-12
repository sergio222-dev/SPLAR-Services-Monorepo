#region Imports

using SPAR.Shared.Domain.Bus.Command;
using Newtonsoft.Json;

#endregion

namespace SPLAR.Wiki.Animes.Application.Create
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class AnimeCreateCommand : ICommand
    {
        #region Properties

        [JsonProperty] public string AnimeName { get; private set; }

        [JsonProperty] public string AnimeId { get; private set; }

        [JsonProperty] public string StudioId { get; private set; }

        #endregion

        #region Constructs

        private AnimeCreateCommand() {}
        
        public AnimeCreateCommand(string sAnimeName, string sAnimeId, string sStudioId)
        {
            AnimeName = sAnimeName;
            AnimeId = sAnimeId;
            StudioId = sStudioId;
        }

        #endregion
    }
}