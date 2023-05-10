using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManagmentAPI.Dto;
using UserManagmentAPI.Interfaces;
using UserManagmentAPI.Models;


namespace UserManagmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser userRepository;
        private readonly IMapper mapper;

        public UserController(IUser userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> GetUsers() 
        { 
            var users = await Task.Run(() =>
                mapper.Map<List<User>>(userRepository.GetUsers()));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (!userRepository.UserExists(id))
                return NotFound();

            var user = await Task.Run(() => 
                mapper.Map<User>(userRepository.GetUserById(id)));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpGet("/login/{login}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserByUsername(string login)
        {
            var user = await Task.Run(() => 
                userRepository.GetUserByUsername(login));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userCreate)
        {
            if (userCreate == null) return BadRequest();

            // Проверка свободноло логина
            var user = userRepository.GetUsers()
               .Where(u => u.Login.Trim().ToUpper() == userCreate.Login.Trim().ToUpper()).FirstOrDefault();
            if (user != null)
            {
                ModelState.AddModelError("", "User already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest();

            var userMap = mapper.Map<User>(userCreate);

            if (!userRepository.CreateUser(userMap)) 
            {
                ModelState.AddModelError("", "Error while saving");
                return StatusCode(500, ModelState);
            }
            
            await Task.Delay(TimeSpan.FromSeconds(5));

            return Ok("User created");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!userRepository.UserExists(id)) 
                return NotFound();

            var userToDelete = await Task.Run(() => 
                userRepository.GetUserById(id));
            
            if (!ModelState.IsValid)
                return BadRequest();

            if (!userRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Error while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}