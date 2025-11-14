using Core.Entities;

namespace Core.IRepositories;
public interface IUserRepository
{
    Task<User> GetAsync(Guid id);
    Task<List<User>> GetAllAsync();
    Task<int> CreateAsync(User command);
    
}