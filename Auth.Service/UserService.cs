using System.Threading.Tasks;
using Auth.DbRepository;
using Auth.Dto;
using Auth.Service.Interface;

namespace Auth.Service
{
    public class UserService : DbContext, IUserService
    {
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <returns></returns>
        public async Task<bool> ExistAsync(int Id)
        {
            return await UserDb.IsAnyAsync(t => t.Id == Id);
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public async Task<bool> ExistAsync(string UserName)
        {
            return await UserDb.IsAnyAsync(t => t.UserName == UserName);
        }

        public async Task<bool> ExistAsync(string UserName, string Password)
        {
            return await UserDb.IsAnyAsync(t => t.UserName == UserName & t.Password == Password);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <returns></returns>
        public async Task<UserDto> GetUserAsync(int Id)
        {
            var entity = await UserDb.SingleAsync(t => t.Id == Id);
            if (entity != null)
            {
                var dto = new UserDto
                {
                    Id = entity.Id,
                    UserName = entity.UserName
                };
                return dto;
            }
            return null;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public async Task<UserDto> GetUserAsync(string UserName)
        {
            var entity = await UserDb.SingleAsync(t => t.UserName == UserName);
            if (entity != null)
            {
                var dto = new UserDto
                {
                    Id = entity.Id,
                    UserName = entity.UserName
                };
                return dto;
            }
            return null;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public async Task<UserDto> GetUserAsync(string UserName, string Password)
        {
            var entity = await UserDb.SingleAsync(t => t.UserName == UserName & t.Password == Password);
            if (entity != null)
            {
                var dto = new UserDto
                {
                    Id = entity.Id,
                    UserName = entity.UserName
                };
                return dto;
            }
            return null;
        }
    }
}