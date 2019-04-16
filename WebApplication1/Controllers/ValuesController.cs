using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Value控制器
    /// </summary>
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Get方法
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Description("哈哈哈")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}