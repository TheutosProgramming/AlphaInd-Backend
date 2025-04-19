using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController(IMemberService memberService) : ControllerBase
{
    private readonly IMemberService _memberService = memberService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _memberService.GetMembersAsync();
        return Ok(result);
    }
}
