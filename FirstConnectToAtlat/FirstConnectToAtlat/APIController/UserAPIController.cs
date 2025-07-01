using FirstConnectToAtlat.Models;
using FirstConnectToAtlat.Service;
using Microsoft.AspNetCore.Mvc;

namespace FirstConnectToAtlat.APIController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAPIController : ControllerBase
    {
        private readonly UserService _userService;
        public UserAPIController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Create_NewUser")]

        public async Task<IActionResult> CreateNewUser(User newuser)
        {
            await _userService.CreateNewUser(newuser);
            return Ok(newuser); 
        }
    }
}
