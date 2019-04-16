using System.Threading.Tasks;
using Auth.DbRepository;
using Auth.Entities;
using Auth.Service.Interface;

namespace Auth.Service
{
    public class ClientService : DbContext, IClientService
    {
        /// <summary>
        /// 判断客户端是否存在
        /// </summary>
        /// <param name="ClientId">客户端ID</param>
        /// <returns></returns>
        public async Task<bool> ExistAsync(string ClientId)
        {
            return await ClientDb.IsAnyAsync(t => t.Id == ClientId);
        }

        /// <summary>
        /// 判断客户端是否存在
        /// </summary>
        /// <param name="ClientId"></param>
        /// <param name="ClientSecret"></param>
        /// <returns></returns>
        public async Task<bool> ExistAsync(string ClientId, string ClientSecret)
        {
            return await ClientDb.IsAnyAsync(t => t.Id == ClientId & t.Secret == ClientSecret);
        }

        /// <summary>
        /// 获取客户端
        /// </summary>
        /// <param name="ClientId">客户端ID</param>
        /// <returns></returns>
        public async Task<ClientEntity> GetClientAsync(string ClientId)
        {
            return await ClientDb.SingleAsync(t => t.Id == ClientId);
        }

        /// <summary>
        /// 获取客户端
        /// </summary>
        /// <param name="ClientId"></param>
        /// <param name="ClientSecret"></param>
        /// <returns></returns>
        public async Task<ClientEntity> GetClientAsync(string ClientId, string ClientSecret)
        {
            return await ClientDb.SingleAsync(t => t.Id == ClientId & t.Secret == ClientSecret);
        }
    }
}