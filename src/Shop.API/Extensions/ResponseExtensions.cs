using Shop.Domain.Common.Models;

namespace Shop.API.Extensions;

public static class BaseResponseExtensions
{
    public static IResult ToResult<T>(this BaseResponse<T> response)
    {
        if (!response.Success)
        {
            return Results.BadRequest(response);
        }

        return Results.Ok(response);
    }

    public static BaseResponse<T> Ok<T>(T data, string? message = null)
    {
        return new BaseResponse<T>(data, message ?? "Success", true);
    }

    public static BaseResponse<T> BadRequest<T>(string message, T? data = default)
    {
        return new BaseResponse<T>(data!, message, false);
    }

    public static BaseResponse<T> NotFound<T>(string message, T? data = default)
    {
        return new BaseResponse<T>(data!, message, false);
    }

    public static BaseResponse<T> Created<T>(T data, string? message = null)
    {
        return new BaseResponse<T>(data, message ?? "Created successfully", true);
    }

    public static IResult OkResult<T>(T data, string? message = null)
    {
        return Results.Ok(Ok(data, message));
    }

    public static IResult BadRequestResult<T>(string message, T? data = default)
    {
        return Results.BadRequest(BadRequest(message, data));
    }

    public static IResult NotFoundResult<T>(string message, T? data = default)
    {
        var response = NotFound(message, data);
        return Results.Json(response, statusCode: StatusCodes.Status404NotFound);
    }

    public static IResult CreatedResult<T>(T data, string? message = null)
    {
        return Results.Created(string.Empty, Created(data, message));
    }
}
