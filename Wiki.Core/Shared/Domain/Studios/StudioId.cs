#region Imports

using System;
using SPAR.Shared.Domain.ValueObject;

#endregion

namespace SPLAR.Wiki.Shared.Domain.Studios
{
    public class StudioId : GuidValueObject
    {
        #region Constructos

        private StudioId()
        {
        }

        public StudioId(Guid oStudioId) : base(oStudioId)
        {
        }

        #endregion
    }
}