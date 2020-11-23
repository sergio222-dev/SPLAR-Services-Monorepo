using System;

namespace SPLAR.Shared.Domain.ValueObjects
{
    public class GuidValueObject
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

        #region Constructos

        public GuidValueObject(Guid oValue)
        {
            _oValue = oValue;
        }

        #endregion
    }
}