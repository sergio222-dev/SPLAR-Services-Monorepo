#region Imports

using SPLAR.Wiki.Shared.Domain.Studios;

#endregion

namespace SPAR.Wiki.Studios.Domain
{
    public class Studio
    {
        #region Variables

        private StudioId _oId;
        private StudioName _oName;
        private StudioAnimes _oStudioAnimes;

        #endregion

        #region Constructs

        public Studio(
            StudioId oStudioId,
            StudioName oStudioName,
            StudioAnimes oStudioAnimes
        )
        {
            _oId = oStudioId;
            _oName = oStudioName;
            _oStudioAnimes = oStudioAnimes;
        }

        #endregion
    }
}