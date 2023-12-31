﻿using AcceptanceCRUD.Brokers.Storages;
using AcceptanceCRUD.Models.Users;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace AcceptanceCRUD.Services
{
    public partial class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;

        public UserService(
            IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        public async ValueTask<User> AddUserAsync(User user) =>
            await this.storageBroker.InsertUserAsync(user);

        public async ValueTask<User> RetrieveUserByIdAsync(Guid userId) =>
            await this.storageBroker.SelectUserByIdAsync(userId);

        public IQueryable<User> RetrieveAllUsers() =>
            this.storageBroker.SelectAllUsers();

        public async ValueTask<User> ModifyUserAsync(User user) =>
            await this.storageBroker.UpdateUserAsync(user);

        public async ValueTask<User> RemoveUserAsync(Guid userId)
        {
            User maybeUser =
                await this.storageBroker.SelectUserByIdAsync(userId);

            return await this.storageBroker.DeleteUserAsync(maybeUser);
        }
    }
}
