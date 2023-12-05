using AcceptanceCRUD.Models.Users;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace AcceptanceCRUD.Services
{
    public interface IUserService
    {
        ValueTask<User> AddUserAsync(User user);
        ValueTask<User> RetrieveUserByIdAsync(Guid userId);
        IQueryable<User> RetrieveAllUsers();
        ValueTask<User> ModifyUserAsync(User user);
        ValueTask<User> RemoveUserAsync(Guid userId);
    }
}
