using System.Collections.Generic;
using System.Web.Http;
using Auth.Dto;
using ResourceServer.Model;

namespace ResourceServer.Controllers
{
    /// <summary>
    /// 这是List
    /// </summary>
    public class ListTestController : BaseController
    {
        /// <summary>
        /// 返回集合
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResult<List<UserDto>> GetResult(UserDto userDto)
        {
            List<UserDto> userDtos = new List<UserDto>() {
                new UserDto{
                     Id=1,
                      UserName="2"
                },
                new UserDto{
                     Id=3,
                      UserName="4"
                }
            };
            return Success(userDtos);
        }
    }
}
