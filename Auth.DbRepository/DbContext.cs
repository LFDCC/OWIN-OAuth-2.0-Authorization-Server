using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Auth.Entities;
using SqlSugar;

namespace Auth.DbRepository
{
    public class DbContext
    {
        public SqlSugarClient Db { get; set; }

        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConfigurationManager.AppSettings["ConnectionString"],
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,
            });
            //调式代码 用来打印SQL
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
        }

        public DbSet<UserEntity> UserDb { get { return new DbSet<UserEntity>(Db); } }
        public DbSet<ClientEntity> ClientDb { get { return new DbSet<ClientEntity>(Db); } }
        
    }
}