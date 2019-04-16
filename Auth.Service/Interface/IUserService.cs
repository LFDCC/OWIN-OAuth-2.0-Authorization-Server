using System.Threading.Tasks;
using Auth.Entities;
using Auth.Infrastructure.Ioc;

namespace Auth.Service.Interface
{
    public interface IUserService : IDependency
    {
        Task<UserEntity> GetUserAsync(int Id);

        Task<UserEntity> GetUserAsync(string UserName);

        Task<UserEntity> GetUserAsync(string UserName, string Password);

        Task<bool> ExistAsync(int Id);

        Task<bool> ExistAsync(string UserName);

        Task<bool> ExistAsync(string UserName, string Password);
    }
}