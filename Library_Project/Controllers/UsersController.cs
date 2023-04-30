using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library_Project.Data;
using Library_Project.Models;
using Library_Project.Interfaces;
using AutoMapper;
using Library_Project.Dto;

namespace Library_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<UserDto>))]
        [ProducesResponseType(400)]

        public IActionResult GetUsers()
        {
            
            List<User> users = _userService.GetUsers();

            //mapping
            List<UserDto> response = _mapper.Map<List<User>, List<UserDto>>(users);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(response);
        }

        [HttpGet("id/{userId}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]


        public IActionResult GetUser(int userId) 
        {
            if (!_userService.UserExists(userId))
                return NotFound();

            User user = _userService.GetUser(userId);

            //mapping
            UserDto response = _mapper.Map<User, UserDto>(user);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(response);
        }


        [HttpGet("username/{username}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetUser(string username)
        {
            if(!_userService.UserExists(username))
                return NotFound();

            User user = _userService.GetUser(username);

            //mapping
            UserDto response = _mapper.Map<User, UserDto>(user);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(response);
        }
    }
}
