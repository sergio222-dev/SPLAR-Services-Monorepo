using Bogus;

namespace SPLAR.Shared.Test.Domain
{
    public sealed class WordMother
    {
        public static string Create()
        {
            return new Faker().Random.Word();
        }
    }
}