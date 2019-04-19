using System.Threading.Tasks;

using Auth.Entities;
using Auth.Infrastructure.Ioc;

namespace Auth.Service.Interface
{
    public interface IClientService : IDependency

    {
        Task<ClientEntity> GetClientAsync(string ClientId, string ClientSecret);

        Task<ClientEntity> GetClientAsync(string ClientId);

        Task<bool> ExistAsync(string ClientId, string ClientSecret);

        Task<bool> ExistAsync(string ClientId);
    }
}