using MediatR;
using Shop.Application.DTOs;

namespace Shop.Application.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto?>;

