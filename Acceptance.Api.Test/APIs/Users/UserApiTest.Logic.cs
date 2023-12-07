using Acceptance.Api.Test.Brokers;
using AcceptanceCRUD.Models.Users;
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

        [Fact]
        public async Task ShouldPutUserAsync()
        {
            // given
            User randomUser = await PostRandomUserAsync();
            User modifiedUser = UpdateRandomUserAsunc(randomUser);

            // when
            await this.acceptanceApiBroker.PutUserAsync(modifiedUser);

            User actualUser =
                await this.acceptanceApiBroker.GetUserByIdAsync(randomUser.Id);

            // then
            actualUser.Should().BeEquivalentTo(modifiedUser);
            await this.acceptanceApiBroker.DeleteUserByIdAsync(actualUser.Id);
        }
    }
}
