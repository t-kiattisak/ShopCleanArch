namespace Shop.Domain.Common.Models;

public class BaseResponse<T>(T data, string message, bool success)
{
    public T Data { get; set; } = data;
    public string Message { get; set; } = message;
    public bool Success { get; set; } = success;
}