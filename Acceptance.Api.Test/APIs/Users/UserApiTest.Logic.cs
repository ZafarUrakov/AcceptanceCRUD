using Acceptance.Api.Test.Brokers;
using AcceptanceCRUD.Models.Users;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RESTFulSense.Exceptions;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public async Task ShouldGetAllUsersAsync()
        {
            // given
            IEnumerable<User> randomUsers = GetRandomUsers();
            IEnumerable<User> inputUsers = randomUsers;

            foreach(User user in inputUsers)
            {
                await this.acceptanceApiBroker.PostUserAsync(user);
            }
            
            List<User> expectedUsers = inputUsers.ToList();

            // when
            List<User> actualUsers = await this.acceptanceApiBroker.GetAllUsersAsync();

            // then
            foreach(User expectedUser in expectedUsers)
            {
                User actualUser = actualUsers.Single(u => u.Id == expectedUser.Id);
                actualUser.Should().BeEquivalentTo(expectedUser);
                await this.acceptanceApiBroker.DeleteUserByIdAsync(actualUser.Id);
            }
        }

        [Fact]
        public async Task ShouldDeleteUserAsync()
        {
            // given
            User randomUser = await PostRandomUserAsync();
            User inputUser = randomUser;
            User expectedUser = inputUser;

            // when
            User deletedUser = 
                await this.acceptanceApiBroker.DeleteUserByIdAsync(inputUser.Id);

            ValueTask<User> getUserByIdTask =
                this.acceptanceApiBroker.GetUserByIdAsync(inputUser.Id);

            // then
            deletedUser.Should().BeEquivalentTo(expectedUser);

            await Assert.ThrowsAsync<HttpResponseNotFoundException>(() =>
                getUserByIdTask.AsTask());
        }
    }
}
