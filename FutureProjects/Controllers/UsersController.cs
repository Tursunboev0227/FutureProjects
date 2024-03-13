using DOT.DOMEN.Entities.DTOS;
using DOT.DOMEN.Entities.Models;
using FutureProjects.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutureProjects.API.Controllers
{
    [Route("api/[controller],[action]")]
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
        [HttpPut]
        public async Task<User> UpdateUser(int id, UserDTO model)
        {
            var result = await _userRepository.UpdateAsync(id, model);

            return result;
        }
        [HttpGet]
        public async Task<User> UserGetById(int id)
        {
            var result = await _userRepository.GetByAnyAsync(x => x.Id == id);

            return result;
        }
        [HttpPost]
        public async Task<User> CreateUser(UserDTO model)
        {
            var result = await _userRepository.CreateAsync(model);

            return result;
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            var res = await _userRepository.DeleteAsync(x => x.Id.Equals(id));

            return res;
            
        }
    }
}
