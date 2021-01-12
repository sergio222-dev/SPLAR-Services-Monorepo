using SPAR.Shared.Domain.Bus.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SPAR.Wiki.Animes.Application.Find
{
    public sealed class AnimeFindCommand : ICommand
    {
        #region Variables

        private string _sAnimeName;

        #endregion

        #region Properties

        [JsonProperty] public string AnimeName => _sAnimeName;

        #endregion

        #region Constructs

        public AnimeFindCommand(string sAnimeName)
        {
            _sAnimeName = sAnimeName;
        }

        #endregion

        #region Statics Publics

        // public static ICommand FromJson(string json)
        // {
        //     var data = JObject.Parse(json);
        // }

        #endregion
    }
}