using MediatR;
using Shop.API.Extensions;
using Shop.Application.Interfaces;
using Shop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Shop.Application.Queries.GetProducts.GetProductsQuery).Assembly);
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddEndpoints(typeof(Program).Assembly);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Map("/error", (HttpContext httpContext) =>
{
    var exception = httpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;

    return Results.Problem(
        title: "An unexpected error occurred.",
        detail: app.Environment.IsDevelopment() ? exception?.ToString() : null,
        statusCode: StatusCodes.Status500InternalServerError);
});

app.Run();