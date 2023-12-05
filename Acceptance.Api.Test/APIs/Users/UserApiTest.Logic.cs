using Acceptance.Api.Test.Brokers;
using Acceptance.Api.Test.Models.Users;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Acceptance.Api.Test.APIs.Users
{
    public partial class UserApiTest
    {

        [Fact]
        public async Task ShouldPostUserAsync()
        {
            // given
            User randomUser = CreateRandomUser();
            User inputUser = randomUser;
            User expectedUser = inputUser;

            // when 
            await this.acceptanceApiBroker.PostUserAsync(inputUser);

            User actualUser =
                await this.acceptanceApiBroker.GetUserByIdAsync(inputUser.Id);

            // then
            actualUser.Should().BeEquivalentTo(expectedUser);
            await this.acceptanceApiBroker.DeleteUserByIdAsync(actualUser.Id);
        }
    }
}
