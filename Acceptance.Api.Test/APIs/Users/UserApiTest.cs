﻿using Acceptance.Api.Test.Brokers;
using AcceptanceCRUD.Models.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
         
        private async ValueTask<User> PostRandomUserAsync()
        {
            User randomUser = CreateRandomUser();
            await this.acceptanceApiBroker.PostUserAsync(randomUser);

            return randomUser;
        }

        private static User UpdateRandomUserAsunc(User user)
        {
            user.FirstName = "Test";

            return user;
        }

        private static int GetRandomNumber() => 
            new IntRange(min: 2, max: 20).GetValue();

        private static IEnumerable<User> GetRandomUsers() =>
            CreateRandomUserFiller().Create(GetRandomNumber());
    }
}
