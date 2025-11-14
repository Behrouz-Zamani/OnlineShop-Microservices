using Infrastructure.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly OnlineShopDbContext _context;
    public UnitOfWork(OnlineShopDbContext context )
    {
        _context=context;
    }
    public async Task<int> SaveChangesAsync()
    {
        
       return await _context.SaveChangesAsync();
    }
}