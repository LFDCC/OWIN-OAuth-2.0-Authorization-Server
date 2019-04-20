using System;
using System.Linq;
using System.Security.Cryptography;

using Auth.Entities;

using SqlSugar;

namespace TestingConsole
{
    internal class Program
    {
        private static async System.Threading.Tasks.Task Main(string[] args)
        {
            {
                var Db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = @"server=.\sqlexpress;uid=sa;pwd=ok;database=Auth",
                    DbType = DbType.SqlServer,
                    InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                    IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了
                });
                //调式代码 用来打印SQL
                Db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Console.WriteLine(sql + "\r\n" +
                        Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                    Console.WriteLine();
                };
                //PageModel page = new PageModel
                //{
                //    PageIndex = 1,
                //    PageSize = 10
                //};
                //var result = await Db.Queryable<UserEntity>().Where(t => t.Id == 4444).ToPageListAsync(page.PageIndex, page.PageSize, page.PageCount);
                //page.PageCount = result.Value;
                var f = await Db.Queryable<UserEntity>().SingleAsync(t => t.UserId == 1);
            }
            {
                Console.WriteLine("machineKey");
                Console.WriteLine("decryptionKey：" + CreateKey(24));
                Console.WriteLine("validationKey：" + CreateKey(64));
            }
            Console.ReadLine();
        }

        //生成随机Key 
        public static string CreateKey(int numBytes)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[numBytes];
            rng.GetBytes(buff);
            System.Text.StringBuilder hexString = new System.Text.StringBuilder(64);
            for (int i = 0; i < buff.Length; i++)
            {
                hexString.Append(string.Format("{0:X2}", buff[i]));
            }
            return hexString.ToString();
        }
    }
}