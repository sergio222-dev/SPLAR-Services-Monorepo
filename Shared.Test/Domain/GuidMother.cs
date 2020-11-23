#region Imports

using System;
using Bogus;

#endregion

namespace SPLAR.Shared.Test.Domain
{
    public class GuidMother
    {
        public static Guid Create()
        {
            return new Faker().Random.Guid();
        }
    }
}