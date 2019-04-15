using System.Threading.Tasks;
using Auth.Entities;
using Auth.Service.Interface;

namespace Auth.Service
{
    public class ClientService : IClientService
    {
        /// <summary>
        /// 判断客户端是否存在
        /// </summary>
        /// <param name="ClientId">客户端ID</param>
        /// <returns></returns>
        public Task<bool> Exist(string ClientId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取客户端
        /// </summary>
        /// <param name="ClientId">客户端ID</param>
        /// <returns></returns>
        public Task<ClientEntity> GetClient(string ClientId)
        {
            throw new System.NotImplementedException();
        }
    }
}