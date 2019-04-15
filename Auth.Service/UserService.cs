using System.Threading.Tasks;
using Auth.DbRepository;
using Auth.Entities;
using Auth.Service.Interface;

namespace Auth.Service
{
    public class UserService : DbContext<UserEntity>, IUserService
    {
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <returns></returns>
        public async Task<bool> ExistAsync(int Id)
        {
            await UserDb.GetListAsync();
            return await UserDb.AsQueryable().AnyAsync(t => t.Id == Id);
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public async Task<bool> ExistAsync(string UserName)
        {
            return await UserDb.AsQueryable().AnyAsync(t => t.UserName == UserName);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <returns></returns>
        public async Task<UserEntity> GetUserAsync(int Id)
        {
            return await UserDb.AsQueryable().SingleAsync(t => t.Id == Id);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public async Task<UserEntity> GetUserAsync(string UserName)
        {
            return await UserDb.AsQueryable().SingleAsync(t => t.UserName == UserName);
        }
    }
}