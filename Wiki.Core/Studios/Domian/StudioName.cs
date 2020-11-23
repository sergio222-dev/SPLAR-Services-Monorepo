#region Imports

using SPLAR.Shared.Domain.ValueObjects;

#endregion

namespace SPAR.Wiki.Studios.Domain
{
    public class StudioName : StringValueObject
    {
        #region Constructos

        public StudioName(string sName) : base(sName)
        {
        }

        #endregion
    }
}