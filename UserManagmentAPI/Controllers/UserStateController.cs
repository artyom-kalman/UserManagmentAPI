using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManagmentAPI.Dto;
using UserManagmentAPI.Interfaces;
using UserManagmentAPI.Models;

namespace UserManagmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserSateController : ControllerBase
    {
        //private readonly IUserState userStateRepository;
        //private readonly IMapper mapper;

        //public UserSateController(IUserState userStateRepository, IMapper mapper)
        //{
        //    this.userStateRepository = userStateRepository;
        //    this.mapper = mapper;
        //}

        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<UserState>))]
        //public IActionResult GetUserStates()
        //{
        //    var states = mapper.Map<List<UserStateDto>>(userStateRepository.GetUserStates());

        //    if (!ModelState.IsValid) return BadRequest();

        //    return Ok(states);
        //}

        //[HttpGet("{id}")]
        //[ProducesResponseType(200, Type = typeof(UserState))]
        //[ProducesResponseType(400)]
        //public IActionResult GetUserState(int id)
        //{
        //    var state = mapper.Map<UserStateDto>(userStateRepository.GetUserState(id));

        //    if (!ModelState.IsValid) return BadRequest();

        //    return Ok(state);
        //}
    }
}