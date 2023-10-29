using LongArithmetic.ASP.DTOs;
using LongArithmetic.Core;
using Microsoft.AspNetCore.Mvc;

namespace LongArithmetic.ASP.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubtractController : ControllerBase
{
    [HttpPost]
    public IActionResult SubtractNumbers([FromBody] Request request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        if (x == null || y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber result = x - y;

        return Ok(new Response(result.ToString()));
    }
}