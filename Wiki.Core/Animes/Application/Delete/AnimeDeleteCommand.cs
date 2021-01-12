#region Imports

using SPAR.Shared.Domain.Bus.Command;
using Newtonsoft.Json;

#endregion

namespace SPLAR.Wiki.Animes.Application.Delete
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AnimeDeleteCommand : ICommand
    {
        #region Properties

        [JsonProperty] public string AnimeName { get; private set; }

        #endregion

        #region Constructs
        
        private AnimeDeleteCommand() {}

        public AnimeDeleteCommand(string sAnimeName)
        {
            AnimeName = sAnimeName;
        }

        #endregion
    }
}