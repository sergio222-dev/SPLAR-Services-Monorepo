namespace SPAR.Shared.Domain.ValueObject
{
    public class CollectionValueObject<T>
    {
        #region Property

        public T[] Values { get; protected set; }

        #endregion

        #region Constructors
        
        protected CollectionValueObject() {}

        public CollectionValueObject(T[] lstValue)
        {
            Values = lstValue;
        }

        #endregion
    }
}