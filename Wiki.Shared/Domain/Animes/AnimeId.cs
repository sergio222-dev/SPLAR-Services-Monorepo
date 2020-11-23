#region Imports

using System;
using SPLAR.Shared.Domain.ValueObjects;

#endregion

namespace SPLAR.Wiki.Shared.Domain.Animes
{
    public class AnimeId : GuidValueObject
    {
        #region Constructos

        public AnimeId(Guid oId) : base(oId)
        {
        }

        #endregion
    }
}