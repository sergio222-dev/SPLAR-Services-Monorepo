#region Imports

using System;
using SPAR.Shared.Domain.ValueObject;

#endregion

namespace SPLAR.Wiki.Shared.Domain.Animes
{
    public class AnimeId : GuidValueObject
    {
        #region Constructors

        private AnimeId()
        {
        }

        public AnimeId(Guid oValue) : base(oValue) {}
        
        #endregion
    }
}