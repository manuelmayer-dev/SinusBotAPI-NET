namespace SinusBotAPI;

public class SinusBotApiException : Exception
{
    public ErrorCode ErrorCode { get; }

    public SinusBotApiException(ErrorCode errorCode)
    {
        ErrorCode = errorCode;
    }
}