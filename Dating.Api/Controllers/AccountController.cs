using Dating.Api.Features.Account;
using Dating.Api.Features.Members.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dating.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController(IAccountService accountService) : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTOs request)
        {
            try
            {
                var result = await accountService.Register(request);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginDTOs request)
        {
            try
            {
                var result = await accountService.Login(request);

                if (result is null)
                {
                    return Unauthorized("อีเมลหรือรหัสผ่านไม่ถูกต้อง");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return Unauthorized(ex.Message);
            }

        }
    }
}
