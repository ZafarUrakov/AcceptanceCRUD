using Acceptance.Api.Test.Brokers;
using Acceptance.Api.Test.Models.Users;
using Tynamix.ObjectFiller;
using Xunit;

namespace Acceptance.Api.Test.APIs.Users
{
    [Collection(nameof(ApiTestCollection))]
    public partial class UserApiTest
    {
        private readonly AcceptanceApiBroker acceptanceApiBroker;

        public UserApiTest(AcceptanceApiBroker acceptanceApiBroker)
        {
            this.acceptanceApiBroker = acceptanceApiBroker;
        }

        private static User CreateRandomUser() =>
            CreateRandomUserFiller().Create();

        private static Filler<User> CreateRandomUserFiller()
        {
            var filler = new Filler<User>();

            return filler;
        }
    }
}
