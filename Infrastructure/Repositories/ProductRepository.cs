using Core.Entities;
using Core.IRepositories;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Infrastructure.Repository;

public class ProductRepository : IProductRepository
{
    private readonly OnlineShopDbContext _context;
    public ProductRepository(OnlineShopDbContext context)
    {
_context=context;
    }
    public async Task<Product> GetAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public Task<List<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> InsertAsync(Product command)
    {
        await _context.Products.AddAsync(command);
        await _context.SaveChangesAsync();

        return command.Id;

    }
}