using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private static readonly List<Product> _products =
    [
        new Product
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Laptop",
            Description = "High-performance laptop",
            Price = 29999.99m,
            Stock = 10,
            CreatedAt = DateTime.UtcNow.AddDays(-30),
            UpdatedAt = DateTime.UtcNow.AddDays(-5)
        },
        new Product
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Mouse",
            Description = "Wireless mouse",
            Price = 599.99m,
            Stock = 50,
            CreatedAt = DateTime.UtcNow.AddDays(-20),
            UpdatedAt = DateTime.UtcNow.AddDays(-2)
        },
        new Product
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Keyboard",
            Description = "Mechanical keyboard",
            Price = 1999.99m,
            Stock = 25,
            CreatedAt = DateTime.UtcNow.AddDays(-15),
            UpdatedAt = DateTime.UtcNow.AddDays(-1)
        }
    ];

    public Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IEnumerable<Product>>(_products);
    }

    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }
}

