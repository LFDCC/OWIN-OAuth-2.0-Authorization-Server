using System;
using System.Linq;
using Auth.Entities;
using SqlSugar;

namespace TestingConsole
{
    internal class Program
    {
        private static async System.Threading.Tasks.Task Main(string[] args)
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
            var f = await Db.Queryable<UserEntity>().SingleAsync(t => t.Id == 1);
            Console.ReadLine();
        }
    }
}