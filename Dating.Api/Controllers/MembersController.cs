using Dating.Api.Entities;
using Dating.Api.Features.Members;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dating.Api.Controllers
{
    public class MembersController(IMemberService memberService) : BaseController
    {
        /// <summary>
        /// ดึงรายชื่อสมาชิกทั้งหมดในระบบ
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members=await memberService.GetMemberAllAsync();
            return Ok(members);
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
            var result = await memberService.GetMemberByIdAsync(id);

            if (result is null) return NotFound("ไม่พบข้อมูล");

            return Ok(result);
        }
    }
}
