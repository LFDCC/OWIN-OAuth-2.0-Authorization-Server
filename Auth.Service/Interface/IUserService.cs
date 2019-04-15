using System.Threading.Tasks;
using Auth.Entities;

namespace Auth.Service.Interface
{
    public interface IUserService
    {
        Task<UserEntity> GetUserAsync(int Id);

        Task<UserEntity> GetUserAsync(string UserName);

        Task<bool> ExistAsync(int Id);

        Task<bool> ExistAsync(string UserName);
    }
}