using System.Threading.Tasks;
using Auth.Entities;

namespace Auth.Service.Interface
{
    public interface IClientService
    {
        Task<ClientEntity> GetClient(string ClientId);

        Task<bool> Exist(string ClientId);
    }
}