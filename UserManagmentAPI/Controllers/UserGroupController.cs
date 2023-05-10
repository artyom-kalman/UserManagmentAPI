using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManagmentAPI.Dto;
using UserManagmentAPI.Interfaces;
using UserManagmentAPI.Models;
using UserManagmentAPI.Repository;

namespace UserManagmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserGroupController : ControllerBase
    {
        //private readonly IUserGroup userGroupRepository;
        //private readonly IMapper mapper;

        //public UserGroupController(IUserGroup userGroupRepository, IMapper mapper)
        //{
        //    this.userGroupRepository = userGroupRepository;
        //    this.mapper = mapper;
        //}

        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<UserGroup>))]
        //public IActionResult GetUserGroups()
        //{
        //    var groups = mapper.Map<List<UserGroupDto>>(userGroupRepository.GetUserGroups());

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    return Ok(groups);
        //}

        //[HttpGet("{id}")]
        //[ProducesResponseType(200, Type = typeof(UserGroup))]
        //[ProducesResponseType(400)]
        //public IActionResult GetUserGroup(int id)
        //{
        //    var group = mapper.Map<UserGroupDto>(userGroupRepository.GetUserGroup(id));

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    return Ok(group);
        //}
    }
}