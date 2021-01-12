#region Imports

using SPAR.Shared.Domain.ValueObject;

#endregion

namespace SPAR.Wiki.Studios.Domain
{
    public class StudioName : StringValueObject
    {
        #region Constructos

        private StudioName(){}
        
        public StudioName(string sName) : base(sName)
        {
        }

        #endregion
    }
}