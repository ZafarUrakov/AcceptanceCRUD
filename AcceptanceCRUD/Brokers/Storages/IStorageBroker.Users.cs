using AcceptanceCRUD.Models.Users;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace AcceptanceCRUD.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertUserAsync(User user);
        IQueryable<User> SelectAllUsers();
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<User> SelectUserByIdAsync(Guid id);
        ValueTask<User> DeleteUserAsync(User user);
    }
}
