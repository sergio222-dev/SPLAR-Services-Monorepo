namespace SPLAR.Shared.Domain.ValueObjects
{
    public class CollectionValueObject<T>
    {
        #region Variables

        private T[] _lstValue;

        #endregion

        #region Property

        public T[] Values
        {
            get => _lstValue;
        }

        #endregion

        #region Constructors

        public CollectionValueObject(T[] lstValue)
        {
            _lstValue = lstValue;
        }

        #endregion
    }
}