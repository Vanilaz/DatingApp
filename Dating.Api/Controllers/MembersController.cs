using Dating.Api.Data;
using Dating.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dating.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        /// <summary>
        /// ดึงรายชื่อสมาชิกทั้งหมดในระบบ
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var result = await context.AppUsers.AsNoTracking().ToListAsync();
            return Ok(result);
        }

        /// <summary>
        /// ค้นหาข้อมูลสมาชิกตามรหัสประจำตัว (ID)
        /// </summary>
        /// <param name="id">รหัสประจำตัวของสมาชิก (GUID)</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppUser>> GetMemberById(string id)
        {
            var result = await context.AppUsers.FindAsync(id);

            if (result is null) return NotFound("ไม่พบข้อมูล");

            return Ok(result);
        }
    }
}
