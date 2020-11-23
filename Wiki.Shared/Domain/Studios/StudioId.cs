#region Imports

using System;
using SPLAR.Shared.Domain.ValueObjects;

#endregion

namespace SPLAR.Wiki.Shared.Domain.Studios
{
    public class StudioId : GuidValueObject
    {
        #region Constructos

        public StudioId(Guid oStudioId) : base(oStudioId)
        {
        }

        #endregion
    }
}