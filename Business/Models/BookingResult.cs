namespace Business.Models;

public class BookingResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
    public int StatusCode { get; set; } = 200;

    public static BookingResult CreateSuccess(int statusCode = 200) => new()
    {
        Success = true,
        StatusCode = statusCode
    };

    public static BookingResult CreateFailure(string error, int statusCode = 400) => new()
    {
        Success = false,
        Error = error,
        StatusCode = statusCode
    };
}

public class BookingResult<T> : BookingResult
{
    public T? Result { get; set; }

    public static BookingResult<T> CreateSuccess(T result, int statusCode = 200) => new()
    {
        Success = true,
        StatusCode = statusCode,
        Result = result
    };

    public new static BookingResult<T> CreateFailure(string error, int statusCode = 400) => new()
    {
        Success = false,
        Error = error,
        StatusCode = statusCode
    };
}