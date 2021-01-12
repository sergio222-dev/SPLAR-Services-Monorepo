namespace SPAR.Shared.Domain.ValueObject
{
    public abstract class StringValueObject
    {

        #region Property

        public string Value { get; protected set; }
        
        #endregion

        #region Constructors

        protected StringValueObject() {}
        
        protected StringValueObject(string sValue)
        {
            Value = sValue;
        }
        
        #endregion
    }
}