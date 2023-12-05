using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Acceptance.Api.Test.Models.Users;
using Microsoft.Extensions.Logging;

namespace Acceptance.Api.Test.Brokers
{
    public partial class AcceptanceApiBroker
    {
        private const string UsersRelativeUrl = "api/users";

        public async ValueTask<User> PostUserAsync(User user) =>
            throw new NotImplementedException();
        public async ValueTask<User> GetUserByIdAsync(Guid userId) =>
            await this.apiFactoryClient.GetContentAsync<User>($"{UsersRelativeUrl}/{userId}");

        public async ValueTask<User> DeleteUserByIdAsync(Guid userId) =>
            await this.apiFactoryClient.DeleteContentAsync<User>($"{UsersRelativeUrl}/{userId}");

        public async ValueTask<User> PutUserAsync(User user) =>
            await this.apiFactoryClient.PutContentAsync(UsersRelativeUrl, user);

        public async ValueTask<List<User>> GetAllUsersAsync() =>
            await this.apiFactoryClient.GetContentAsync<List<User>>($"{UsersRelativeUrl}/");
    }
}
