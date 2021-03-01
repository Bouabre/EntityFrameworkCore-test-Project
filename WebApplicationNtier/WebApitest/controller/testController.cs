using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IService;

namespace WebApitest.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;

        public testController(IUserService userService, IUserProfileService userProfileService)
        {
            _userService = userService;
            _userProfileService = userProfileService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetTodoItem(long id)
        {
            var todoItem = _userService.GetUser(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var todoItem = _userService.GetUser(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.UserName = user.UserName;
            todoItem.Email = user.Email;

            try
            {
                _userService.UpdateUser(todoItem);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateTodoItem(User todoItemDTO)
        {
            var todoItem = new User
            {
                UserName = todoItemDTO.UserName,
                Email = todoItemDTO.Email,
                Password = todoItemDTO.Password,
                PhoneNumber = todoItemDTO.PhoneNumber,
                UserProfile = new UserProfile{
           FirstName= todoItemDTO.UserProfile.FirstName,
           LastName= todoItemDTO.UserProfile.LastName,
           Address= todoItemDTO.UserProfile.Address
                }

    };

            _userService.InsertUser(todoItem);

            return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = todoItem.Id },
                ItemToDTO(todoItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem =  _userService.GetUser(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);

            return NoContent();
        }
        private static User ItemToDTO(User todoItem) =>
    new User
    {
        Id = todoItem.Id,
        UserName = todoItem.UserName,
        Email = todoItem.Email
    };
    
    }
}
