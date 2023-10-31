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

    [HttpPost("pow")]
    public IActionResult Pow([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        BigNumber result = BigNumber.Pow(x, y);

        return Ok(new BaseResponse(result.ToString()));
    }

    [HttpPost("abs")]
    public IActionResult Abs([FromBody] SingleItemRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);

        BigNumber result = BigNumber.Abs(x);

        return Ok(new BaseResponse(result.ToString()));
    }

    [HttpPost("mod")]
    public IActionResult Mod([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        BigNumber result = BigNumber.Mod(x, y);

        return Ok(new BaseResponse(result.ToString()));
    }

    [HttpPost("factorial")]
    public IActionResult Factorial([FromBody] SingleItemRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);

        BigNumber result = BigNumber.Factorial(x);

        return Ok(new BaseResponse(result.ToString()));
    }

    [HttpPost("gcd")]
    public IActionResult GreatestCommonDivisor([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        BigNumber result = BigNumber.GreatestCommonDivisor(x, y);

        return Ok(new BaseResponse(result.ToString()));
    }

    [HttpPost("gcd")]
    public IActionResult LeastCommonMultiple([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        BigNumber result = BigNumber.LeastCommonMultiple(x, y);

        return Ok(new BaseResponse(result.ToString()));
    }

    [HttpPost("greaterthan")]
    public IActionResult GreaterThan([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        bool result = x > y;

        return Ok(new BoolResponse(result));
    }

    [HttpPost("lessthan")]
    public IActionResult LessThan([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        bool result = x < y;

        return Ok(new BoolResponse(result));
    }

    [HttpPost("greaterthanorequalto")]
    public IActionResult GreaterThanOrEqualTo([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        bool result = x >= y;

        return Ok(new BoolResponse(result));
    }

    [HttpPost("lessthanorequalto")]
    public IActionResult LessThanOrEqualTo([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        bool result = x <= y;

        return Ok(new BoolResponse(result));
    }

    [HttpPost("equalto")]
    public IActionResult EqualTo([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        bool result = x == y;

        return Ok(new BoolResponse(result));
    }

    [HttpPost("notequalto")]
    public IActionResult NotEqualTo([FromBody] BaseRequest request)
    {
        if (request == null)
            return BadRequest("Неверные данные запроса.");

        if (request.X == null || request.Y == null)
            return BadRequest("Недопустимые вводимые числа.");

        BigNumber x = new BigNumber(request.X);
        BigNumber y = new BigNumber(request.Y);

        bool result = x != y;

        return Ok(new BoolResponse(result));
    }
}