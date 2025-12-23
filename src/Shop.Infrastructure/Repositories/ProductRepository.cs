using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Infrastructure.Data;

namespace Shop.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FindAsync([id], cancellationToken);
    }
}

