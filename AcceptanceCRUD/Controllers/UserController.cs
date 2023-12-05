using AcceptanceCRUD.Models.Users;
using AcceptanceCRUD.Services;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AcceptanceCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : RESTFulController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService) =>
            this.userService = userService;

        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUserAsync(User user)
        {
            User registeredUser =
                await this.userService.AddUserAsync(user);

            return Created(registeredUser);

        }

        [HttpGet]
        public ActionResult<IQueryable<User>> GetAllUsers()
        {
            IQueryable storageUsers =
                this.userService.RetrieveAllUsers();

            return Ok(storageUsers);
        }

        [HttpGet("{userId}")]
        public async ValueTask<ActionResult<User>> GetUserByIdAsync(Guid userId)
        {
            User storageUser =
                await this.userService.RetrieveUserByIdAsync(userId);

            return Ok(storageUser);
        }

        [HttpPut]
        public async ValueTask<ActionResult<User>> PutUserAsync(User user)
        {
            User registeredUser =
                await this.userService.ModifyUserAsync(user);

            return Ok(registeredUser);
        }

        [HttpDelete("{userId}")]
        public async ValueTask<ActionResult<User>> DeleteUserAsync(Guid userId)
        {
            User storageUser =
                await this.userService.RemoveUserAsync(userId);

            return Ok(storageUser);
        }
    }
}
