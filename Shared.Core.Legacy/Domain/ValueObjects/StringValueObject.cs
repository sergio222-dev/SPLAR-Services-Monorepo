namespace SPLAR.Shared.Domain.ValueObjects
{
    public abstract class StringValueObject
    {
        #region Variables

        private string _sValue;

        #endregion

        #region Property

        public string Value => _sValue;

        #endregion

        #region Constructors

        public StringValueObject()
        {
        }
        
        public StringValueObject(string sValue)
        {
            _sValue = sValue;
        }

        #endregion
    }
}