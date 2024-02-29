using DOT.DOMEN.Entities.Models;
using FutureProjects.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutureProjects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        [HttpGet]

        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var res = await _userRepository.GetAllAsync();
            return Ok(res);
        }
    }
}
