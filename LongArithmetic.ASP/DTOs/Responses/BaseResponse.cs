namespace LongArithmetic.ASP.DTOs.Responses;

public class BaseResponse
{
    public string Result { get; set; }

    public BaseResponse(string result)
    {
        Result = result;
    }
}