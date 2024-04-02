using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;
using ASP.NET_Core_Web_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("withInsurancePolicies")]
        public async Task<IActionResult> GetAllUsersWithInsurancePolicies()
        {
            var users = await _userRepository.GetAllUsersWithInsurancePolicies();
            return Ok(users);
        }

        [HttpGet("{id}/withInsurancePolicies")]
        public async Task<IActionResult> GetUserByIdWithInsurancePolicies(int id)
        {
            var user = await _userRepository.GetUserByIdWithInsurancePolicies(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// The method now accepts a DTO (Data Transfer Object) named CreateUserDto instead of the User entity directly. 
        /// Using a DTO allows you to control which properties are accepted from the client and provides flexibility for 
        /// future changes without impacting the API contract.
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map the DTO to the User entity
            var user = new User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email
                // You can also set other properties if needed
            };

            // Create the user
            await _userRepository.CreateUser(user);

            // Return the created user
            return CreatedAtAction(nameof(GetUserById), new { id = user.ID }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto updateDto)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            // Update user properties
            user.Name = updateDto.Name;
            user.Email = updateDto.Email;

            await _userRepository.UpdateUser(user);

            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
