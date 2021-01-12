#region Imports

using SPAR.Shared.Domain.ValueObject;

#endregion

namespace SPAR.Wiki.Animes.Domain
{
    public class AnimeName : StringValueObject
    {
        #region Constructors

        private AnimeName()
        {
        }

        public AnimeName(string sName) : base(sName) {}

        #endregion
    }
}