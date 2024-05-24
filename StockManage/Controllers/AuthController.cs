using Microsoft.AspNetCore.Mvc;
using StockManageService;

namespace StockManage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AuthController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult GetAccount(string email, string password)
        {
            var account = _accountService.GetAccount(email, password);
            if (account == null)
            {
                return Unauthorized();
            }

            var token = _tokenService.GenerateToken(account.Email);
            return Ok(new { Token = token });
          
        }


    }

}
