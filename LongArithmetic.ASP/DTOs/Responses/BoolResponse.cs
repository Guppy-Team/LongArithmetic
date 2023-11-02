namespace LongArithmetic.ASP.DTOs.Responses;

public class BoolResponse
{
    public bool Result { get; set; }

    public BoolResponse(bool result)
    {
        Result = result;
    }
}