using Core.Entities;
using Core.IRepositories;

namespace Infrastructure.Repository;

public class Userrepository : IUserRepository
{
    #region CTOR
        private readonly OnlineShopDbContext _context;
        public Userrepository(OnlineShopDbContext context)
        {
            _context=context;
        }
    #endregion
    public async Task<int> CreateAsync(User command)
    {
        await _context.Users.AddAsync(command);
        await _context.SaveChangesAsync();
        return command.Id;

    }

    public async Task<List<User>> GetAllAsync()
    {
       //return await _context.Users();
       throw new NotImplementedException();
    }

    public async Task<User> GetAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }
}