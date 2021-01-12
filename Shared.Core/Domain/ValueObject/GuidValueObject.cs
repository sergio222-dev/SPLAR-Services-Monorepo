#region Imports

using System;

#endregion

namespace SPAR.Shared.Domain.ValueObject
{
    public abstract class GuidValueObject
    {
        #region Property

        public Guid Value { get; protected set; }

        #endregion

        #region Constructors

        protected GuidValueObject()
        {
        }

        protected GuidValueObject(Guid oValue)
        {
            Value = oValue;
        }

        #endregion
    }
}