using BrazInvest.API.Helpers;
using Infrastructure.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace BrazInvest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {

            try
            {
                var ret = _userService.AddUser(request.User, request.Password, request.Email);

                if (ret != null)
                {
                    return Ok(new { Username = ret.UserName, Email = ret.Email, UserID = ret.UserId });
                }

                return BadRequest("Invalid user data. Please check and try again.");
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }
}
