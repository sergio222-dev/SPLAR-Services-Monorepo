#region Imports

using Moq;

#endregion

namespace SPLAR.Shared.Test.Infrastructure
{
    public abstract class UnitTestCase
    {
        public Mock<T> Mock<T>() where T : class
        {
            return new Mock<T>(); 
        }
    }
}