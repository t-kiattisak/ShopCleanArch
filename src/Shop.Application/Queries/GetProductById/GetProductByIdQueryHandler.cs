using MediatR;
using Shop.Application.DTOs;
using Shop.Application.Interfaces;

namespace Shop.Application.Queries.GetProductById;

public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product == null)
        {
            return null;
        }

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity
        };
    }
}

