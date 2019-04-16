using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Auth.Infrastructure.Tools.Encrypt
{
    public class Sha256
    {
        /// <summary>
        /// 将字符串转换为sha256散列
        /// </summary>
        /// <param name="data">字符串进行转换</param>
        /// <returns>sha256散列或null</returns>
        public static string Encrypt(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    return null;
                }

                SHA256 sha = new SHA256CryptoServiceProvider();
                var hashValue = sha.ComputeHash(Encoding.UTF8.GetBytes(data));
                var hex = hashValue.Aggregate("", (current, x) => current + String.Format("{0:x2}", x));

                if (string.IsNullOrEmpty(hex))
                {
                    throw new Exception("Erro creating SHA256 hash");
                }

                return hex;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}