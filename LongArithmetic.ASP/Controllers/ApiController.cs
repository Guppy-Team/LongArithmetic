using LongArithmetic.ASP.DTOs.Requests;
using LongArithmetic.ASP.DTOs.Responses;
using LongArithmetic.Core;
using Microsoft.AspNetCore.Mvc;

namespace LongArithmetic.ASP.Controllers;

[Route("[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    [HttpPost("add")]
    public IActionResult Add([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        BigNumber result = x + y;

        return Ok(new BaseResponse(result.ToString()));
    }

    [HttpPost("subtract")]
    public IActionResult Subtract([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        BigNumber result = x - y;

        return Ok(new BaseResponse(result.ToString()));
    }

    [HttpPost("multiply")]
    public IActionResult Multiply([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        BigNumber result = x * y;

        return Ok(new BaseResponse(result.ToString()));
    }

    [HttpPost("divide")]
    public IActionResult Divide([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        BigNumber result = x / y;

        return Ok(new BaseResponse(result.ToString()));
    }
}
