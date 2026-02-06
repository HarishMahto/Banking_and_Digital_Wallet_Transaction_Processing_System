using BankingDigitalWallet.Api.DTOs;
using BankingDigitalWallet.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankingDigitalWallet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var result = await _userService.CreateAsync(dto);
            return Ok(result);
        }
    }
}
