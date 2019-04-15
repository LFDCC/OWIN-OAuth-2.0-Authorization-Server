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
    public class DbContext<T> where T : class, new()
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

        public SimpleClient<UserEntity> UserDb { get { return new SimpleClient<UserEntity>(Db); } }
        public SimpleClient<ClientEntity> ClientDb { get { return new SimpleClient<ClientEntity>(Db); } }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList()
        {
            return Db.Queryable<T>().ToList();
        }

        /// <summary>
        /// 获取所有（异步）
        /// </summary>
        /// <returns></returns>
        public virtual Task<List<T>> GetListAsync()
        {
            return Db.Queryable<T>().ToListAsync();
        }

        /// <summary>
        /// 根据表达式查询
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> whereExpression)
        {
            return Db.Queryable<T>().Where(whereExpression).ToList();
        }

        /// <summary>
        /// 根据表达式查询（异步）
        /// </summary>
        /// <returns></returns>
        public virtual Task<List<T>> GetListAsync(Expression<Func<T, bool>> whereExpression)
        {
            return Db.Queryable<T>().Where(whereExpression).ToListAsync();
        }

        /// <summary>
        /// 根据表达式查询分页
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel page)
        {
            int pageCount = 0;
            List<T> result = Db.Queryable<T>().Where(whereExpression).ToPageList(page.PageIndex, page.PageSize, ref pageCount);
            page.PageCount = pageCount;
            return result;
        }

        /// <summary>
        /// 根据表达式查询分页（异步）
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="page"></param>
        /// <returns>Key是集合 Value是总条数</returns>
        public virtual Task<KeyValuePair<List<T>, int>> GetPageListAsync(Expression<Func<T, bool>> whereExpression, PageModel page)
        {
            var result = Db.Queryable<T>().Where(whereExpression).ToPageListAsync(page.PageIndex, page.PageSize, page.PageCount);
            return result;
        }

        /// <summary>
        /// 根据表达式查询分页并排序
        /// </summary>
        /// <param name="whereExpression">it</param>
        /// <param name="pageModel"></param>
        /// <param name="orderByExpression">it=>it.id或者it=>new{it.id,it.name}</param>
        /// <param name="orderByType">OrderByType.Desc</param>
        /// <returns></returns>
        public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
        {
            int pageCount = 0;
            List<T> result = Db.Queryable<T>().OrderByIF(orderByExpression != null, orderByExpression, orderByType).Where(whereExpression)
                .ToPageList(page.PageIndex, page.PageSize, ref pageCount);
            page.PageCount = pageCount;
            return result;
        }

        /// <summary>
        /// 根据表达式查询分页并排序（异步）
        /// </summary>
        /// <param name="whereExpression">it</param>
        /// <param name="pageModel"></param>
        /// <param name="orderByExpression">it=>it.id或者it=>new{it.id,it.name}</param>
        /// <param name="orderByType">OrderByType.Desc</param>
        /// <returns>Key是集合 Value是总条数</returns>
        public virtual Task<KeyValuePair<List<T>, int>> GetPageListAsync(Expression<Func<T, bool>> whereExpression, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
        {
            var result = Db.Queryable<T>().OrderByIF(orderByExpression != null, orderByExpression, orderByType).Where(whereExpression)
                .ToPageListAsync(page.PageIndex, page.PageSize, page.PageCount);
            return result;
        }
    }
}