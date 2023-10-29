namespace LongArithmetic.ASP.DTOs;

public class Response
{
    public string Result { get; set; }

    public Response(string result)
    {
        Result = result;
    }
}