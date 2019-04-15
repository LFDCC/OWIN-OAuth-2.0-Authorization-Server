using System.Threading.Tasks;
using Auth.Entities;

namespace Auth.Service.Interface
{
    public interface IClientService
    {
        Task<ClientEntity> GetClientAsync(string ClientId, string ClientSecret);
        Task<ClientEntity> GetClientAsync(string ClientId);

        Task<bool> ExistAsync(string ClientId, string ClientSecret);
        Task<bool> ExistAsync(string ClientId);
    }
}