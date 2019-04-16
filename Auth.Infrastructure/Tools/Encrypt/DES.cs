using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Auth.Infrastructure.Tools.Encrypt
{
    public class DES
    {
        /// <summary>
        /// 加密数据
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Encrypt(string Text, string sKey)
        {
            var des = new DESCryptoServiceProvider();
            var inputByteArray = Encoding.Default.GetBytes(Text);
            var bKey = Encoding.ASCII.GetBytes(MD5.Encrypt(sKey).Substring(0, 8));
            des.Key = bKey;
            des.IV = bKey;
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            var ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        /// <summary>
        /// 解密数据
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Decrypt(string text, string sKey)
        {
            var des = new DESCryptoServiceProvider();
            var len = text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x;
            for (x = 0; x < len; x++)
            {
                var i = Convert.ToInt32(text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            var bKey = Encoding.ASCII.GetBytes(MD5.Encrypt(sKey).Substring(0, 8));
            des.Key = bKey;
            des.IV = bKey;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }
    }
}