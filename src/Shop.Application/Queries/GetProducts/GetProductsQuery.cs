using MediatR;
using Shop.Application.DTOs;

namespace Shop.Application.Queries.GetProducts;

public record GetProductsQuery : IRequest<IEnumerable<ProductDto>>;

