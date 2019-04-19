using System.Threading.Tasks;

using Auth.Dto;
using Auth.Infrastructure.Ioc;

namespace Auth.Service.Interface
{
    public interface IUserService : IDependency
    {
        Task<UserDto> GetUserAsync(int Id);

        Task<UserDto> GetUserAsync(string UserName);

        Task<UserDto> GetUserAsync(string UserName, string Password);

        Task<bool> ExistAsync(int Id);

        Task<bool> ExistAsync(string UserName);

        Task<bool> ExistAsync(string UserName, string Password);
    }
}