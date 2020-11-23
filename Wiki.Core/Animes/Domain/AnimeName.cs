#region Imports

using SPLAR.Shared.Domain.ValueObjects;

#endregion

namespace SPAR.Wiki.Animes.Domain
{
    public class AnimeName : StringValueObject
    {
        #region Constructors

        public AnimeName(string sName) : base(sName)
        {
        }

        #endregion
    }
}