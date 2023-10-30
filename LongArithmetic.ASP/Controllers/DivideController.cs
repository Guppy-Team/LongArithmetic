using LongArithmetic.ASP.DTOs.Requests;
using LongArithmetic.ASP.DTOs.Responses;
using LongArithmetic.Core;
using Microsoft.AspNetCore.Mvc;

namespace LongArithmetic.ASP.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DivideController : ControllerBase
{
    [HttpPost]
    public IActionResult DivideNumbers([FromBody] BaseRequest baseRequest)
    {
        if (baseRequest == null)
            return BadRequest("Неверные данные запроса.");

        BigNumber x = new BigNumber(baseRequest.X);
        BigNumber y = new BigNumber(baseRequest.Y);

        if (x == null || y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber result = x / y;

        return Ok(new BaseResponse(result.ToString()));
    }
}