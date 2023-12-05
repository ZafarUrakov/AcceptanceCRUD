using Acceptance.Api.Test.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acceptance.Api.Test.Brokers
{
    public partial class AcceptanceApiBroker
    {
        private const string UsersRelativeUrl = "api/users";

        public async ValueTask<User> PostUserAsync(User user) =>
            await this.apiFactoryClient.PostContentAsync(UsersRelativeUrl, user);

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
