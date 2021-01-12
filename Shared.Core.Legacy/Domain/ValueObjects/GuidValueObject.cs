using System;

namespace SPLAR.Shared.Domain.ValueObjects
{
    public abstract class GuidValueObject
    {
        #region Variables

        private Guid _oValue;

        #endregion

        #region Property

        public Guid Value
        {
            get => _oValue;
        }

        #endregion

        #region Constructors

        public GuidValueObject()
        {
        }

        public GuidValueObject(Guid oValue)
        {
            _oValue = oValue;
        }

        #endregion
    }
}