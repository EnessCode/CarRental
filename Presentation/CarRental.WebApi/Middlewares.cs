using CarRental.Application.Common;
using System.Net;
using System.Text.Json;

namespace CarRental.WebApi.Middlewares;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionMiddleware> _logger;

	public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (NotFoundException ex)
		{
			_logger.LogWarning(ex, "Kaynak bulunamadı: {Message}", ex.Message);

			context.Response.StatusCode = (int)HttpStatusCode.NotFound;
			await WriteResponse(context, ex.Message);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Beklenmeyen bir hata oluştu: {Message}", ex.Message);

			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			await WriteResponse(context, "Sunucu tarafında beklenmeyen bir hata oluştu.");
		}
	}

	private static async Task WriteResponse(HttpContext context, string message)
	{
		context.Response.ContentType = "application/json";

		var response = ApiResponse<object>.FailResponse(message);

		var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

		await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
	}
}