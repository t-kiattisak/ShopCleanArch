using MediatR;
using Shop.API.Extensions;
using Shop.Application.DTOs;
using Shop.Application.Queries.GetProductById;
using Shop.Application.Queries.GetProducts;

namespace Shop.API.Endpoints;

public class ProductEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (IMediator mediator) =>
        {
            var query = new GetProductsQuery();
            var products = await mediator.Send(query);
            return BaseResponseExtensions.OkResult(products, "Products retrieved successfully");
        });

        app.MapGet("/products/{id}", async (string id, IMediator mediator) =>
        {
            try
            {
                var query = new GetProductByIdQuery(Guid.Parse(id));
                var product = await mediator.Send(query);

                if (product == null)
                {
                    return BaseResponseExtensions.NotFoundResult<ProductDto>("Product not found");
                }

                return BaseResponseExtensions.OkResult(product, "Product retrieved successfully");
            }
            catch (Exception ex)
            {
                return BaseResponseExtensions.BadRequestResult<ProductDto>($"Error: {ex.Message}");
            }
        });
    }
}
