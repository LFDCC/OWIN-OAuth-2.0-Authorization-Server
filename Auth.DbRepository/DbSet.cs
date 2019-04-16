using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SqlSugar;

namespace Auth.DbRepository
{
    public class DbSet<T> : SimpleClient<T> where T : class, new()
    {
        public DbSet(SqlSugarClient context) : base(context)
        {
        }

        /// <summary>
        /// 根据主键获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> GetByIdAsync(dynamic id)
        {
            return Context.Queryable<T>().InSingle(id);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public Task<List<T>> GetListAsync()
        {
            return Context.Queryable<T>().ToListAsync();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="whereExpression">筛选条件</param>
        /// <returns></returns>
        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> whereExpression)
        {
            return Context.Queryable<T>().Where(whereExpression).ToListAsync();
        }

        /// <summary>
        /// 获取唯一一条数据 多条抛异常
        /// </summary>
        /// <param name="whereExpression">筛选条件</param>
        /// <returns></returns>
        public Task<T> SingleAsync(Expression<Func<T, bool>> whereExpression)
        {
            return Context.Queryable<T>().SingleAsync(whereExpression);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="whereExpression">筛选条件</param>
        /// <param name="page">页码分页条数对象</param>
        /// <returns>Key：集合 Value：总页数</returns>
        public Task<KeyValuePair<List<T>, int>> GetPageListAsync(Expression<Func<T, bool>> whereExpression, PageModel page)
        {
            Task<KeyValuePair<List<T>, int>> result = Context.Queryable<T>().Where(whereExpression).ToPageListAsync(page.PageIndex, page.PageSize, page.PageCount);
            return result;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereExpression">筛选条件</param>
        /// <param name="page">页码分页条数对象</param>
        /// <param name="orderByExpression">如果是Null则使用默认排序orderByType</param>
        /// <param name="orderByType">默认排序</param>
        /// <returns>Key：集合 Value：总页数</returns>
        public Task<KeyValuePair<List<T>, int>> GetPageListAsync(Expression<Func<T, bool>> whereExpression, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
        {
            Task<KeyValuePair<List<T>, int>> result = Context.Queryable<T>().OrderByIF(orderByExpression != null, orderByExpression, orderByType).Where(whereExpression).ToPageListAsync(page.PageIndex, page.PageSize, page.PageCount);
            return result;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="conditionalList">组装条件</param>
        /// <param name="page">页码分页条数对象</param>
        /// <returns>Key：集合 Value：总页数</returns>
        public Task<KeyValuePair<List<T>, int>> GetPageListAsync(List<IConditionalModel> conditionalList, PageModel page)
        {
            Task<KeyValuePair<List<T>, int>> result = Context.Queryable<T>().Where(conditionalList).ToPageListAsync(page.PageIndex, page.PageSize, page.PageCount);
            return result;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="conditionalLis">组装条件</param>
        /// <param name="page">页码分页条数对象</param>
        /// <param name="orderByExpression">如果是Null则使用默认排序orderByType</param>
        /// <param name="orderByType">默认排序</param>
        /// <returns>Key：集合 Value：总页数</returns>
        public Task<KeyValuePair<List<T>, int>> GetPageListAsync(List<IConditionalModel> conditionalLis, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
        {
            Task<KeyValuePair<List<T>, int>> result = Context.Queryable<T>().OrderByIF(orderByExpression != null, orderByExpression, orderByType).Where(conditionalLis).ToPageListAsync(page.PageIndex, page.PageSize, page.PageCount);
            return result;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="whereExpression">筛选条件</param>
        /// <returns></returns>
        public Task<bool> IsAnyAsync(Expression<Func<T, bool>> whereExpression)
        {
            return Context.Queryable<T>().AnyAsync(whereExpression);
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="whereExpression">筛选条件</param>
        /// <returns></returns>
        public Task<int> CountAsync(Expression<Func<T, bool>> whereExpression)
        {
            return Context.Queryable<T>().CountAsync(whereExpression);
        }

        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="insertObj"></param>
        /// <returns></returns>
        public Task<int> InsertAsync(T insertObj)
        {
            return Context.Insertable(insertObj).ExecuteCommandAsync();
        }

        /// <summary>
        /// 插入对象并返回自增列
        /// </summary>
        /// <param name="insertObj"></param>
        /// <returns></returns>
        public Task<int> InsertReturnIdentityAsync(T insertObj)
        {
            return Context.Insertable(insertObj).ExecuteReturnIdentityAsync();
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="insertObjs"></param>
        /// <returns></returns>
        public Task<int> InsertRangeAsync(T[] insertObjs)
        {
            return Context.Insertable(insertObjs).ExecuteCommandAsync();
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="insertObjs"></param>
        /// <returns></returns>
        public Task<int> InsertRangeAsync(List<T> insertObjs)
        {
            return Context.Insertable(insertObjs).ExecuteCommandAsync();
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="updateObj"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync(T updateObj)
        {
            return Context.Updateable(updateObj).ExecuteCommandAsync();
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="updateObj"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync(T[] updateObj)
        {
            return Context.Updateable(updateObj).ExecuteCommandAsync();
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="updateObj"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync(List<T> updateObj)
        {
            return Context.Updateable(updateObj).ExecuteCommandAsync();
        }

        /// <summary>
        /// 更新指定列
        /// </summary>
        /// <param name="columns">列</param>
        /// <param name="whereExpression">条件</param>
        /// <returns></returns>
        public Task<int> UpdateAsync(Expression<Func<T, T>> columns, Expression<Func<T, bool>> whereExpression)
        {
            return Context.Updateable<T>().UpdateColumns(columns).Where(whereExpression)
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="deleteObj"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync(T deleteObj)
        {
            return Context.Deleteable<T>().Where(deleteObj).ExecuteCommandAsync();
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="whereExpression">条件</param>
        /// <returns></returns>
        public Task<int> DeleteAsync(Expression<Func<T, bool>> whereExpression)
        {
            return Context.Deleteable<T>().Where(whereExpression).ExecuteCommandAsync();
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<int> DeleteByIdAsync(dynamic id)
        {
            return Context.Deleteable<T>(id).ExecuteCommandAsync();
        }

        /// <summary>
        /// 根据主键批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<int> DeleteByIdsAsync(dynamic[] ids)
        {
            return Context.Deleteable<T>().In(ids).ExecuteCommandAsync();
        }
    }
}