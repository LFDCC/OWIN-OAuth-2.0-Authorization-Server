using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SqlSugar;

namespace Auth.DbRepository
{
    public static class SimpleClientExtension
    {
        public static Task<List<T>> GetListAsync<T>(this SimpleClient<T> client) where T : class, new()
        {
            return client.AsQueryable().ToListAsync();
        }

        public static Task<List<T>> GetListAsync<T>(this SimpleClient<T> client, Expression<Func<T, bool>> whereExpression) where T : class, new()
        {
            return client.AsQueryable().Where(whereExpression).ToListAsync();
        }

        public static Task<T> SingleAsync<T>(this SimpleClient<T> client, Expression<Func<T, bool>> whereExpression) where T : class, new()
        {
            return client.AsQueryable().SingleAsync(whereExpression);
        }

        //public List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel page)
        //{
        //    int pageCount = 0;
        //    List<T> result = Context.Queryable<T>().Where(whereExpression).ToPageList(page.PageIndex, page.PageSize, ref pageCount);
        //    page.PageCount = pageCount;
        //    return result;
        //}

        //public List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
        //{
        //    int pageCount = 0;
        //    List<T> result = Context.Queryable<T>().OrderByIF(orderByExpression != null, orderByExpression, orderByType).Where(whereExpression)
        //        .ToPageList(page.PageIndex, page.PageSize, ref pageCount);
        //    page.PageCount = pageCount;
        //    return result;
        //}

        //public List<T> GetPageList(List<IConditionalModel> conditionalList, PageModel page)
        //{
        //    int pageCount = 0;
        //    List<T> result = Context.Queryable<T>().Where(conditionalList).ToPageList(page.PageIndex, page.PageSize, ref pageCount);
        //    page.PageCount = pageCount;
        //    return result;
        //}

        //public List<T> GetPageList(List<IConditionalModel> conditionalList, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
        //{
        //    int pageCount = 0;
        //    List<T> result = Context.Queryable<T>().OrderByIF(orderByExpression != null, orderByExpression, orderByType).Where(conditionalList)
        //        .ToPageList(page.PageIndex, page.PageSize, ref pageCount);
        //    page.PageCount = pageCount;
        //    return result;
        //}

        //public bool IsAny(Expression<Func<T, bool>> whereExpression)
        //{
        //    return Context.Queryable<T>().Where(whereExpression).Any();
        //}

        //public int Count(Expression<Func<T, bool>> whereExpression)
        //{
        //    return Context.Queryable<T>().Where(whereExpression).Count();
        //}

        //public bool Insert(T insertObj)
        //{
        //    return Context.Insertable<T>(insertObj).ExecuteCommand() > 0;
        //}

        //public int InsertReturnIdentity(T insertObj)
        //{
        //    return Context.Insertable<T>(insertObj).ExecuteReturnIdentity();
        //}

        //public bool InsertRange(T[] insertObjs)
        //{
        //    return Context.Insertable<T>(insertObjs).ExecuteCommand() > 0;
        //}

        //public bool InsertRange(List<T> insertObjs)
        //{
        //    return Context.Insertable<T>(insertObjs).ExecuteCommand() > 0;
        //}

        //public bool Update(T updateObj)
        //{
        //    return Context.Updateable<T>(updateObj).ExecuteCommand() > 0;
        //}

        //public bool UpdateRange(T[] updateObjs)
        //{
        //    return Context.Updateable<T>(updateObjs).ExecuteCommand() > 0;
        //}

        //public bool UpdateRange(List<T> updateObjs)
        //{
        //    return Context.Updateable<T>(updateObjs).ExecuteCommand() > 0;
        //}

        //public bool Update(Expression<Func<T, T>> columns, Expression<Func<T, bool>> whereExpression)
        //{
        //    return Context.Updateable<T>().UpdateColumns(columns).Where(whereExpression)
        //        .ExecuteCommand() > 0;
        //}

        //public bool Delete(T deleteObj)
        //{
        //    return Context.Deleteable<T>().Where(deleteObj).ExecuteCommand() > 0;
        //}

        //public bool Delete(Expression<Func<T, bool>> whereExpression)
        //{
        //    return Context.Deleteable<T>().Where(whereExpression).ExecuteCommand() > 0;
        //}

        //public bool DeleteById(dynamic id)
        //{
        //    if (_003C_003Eo__36._003C_003Ep__3 == null)
        //    {
        //        _003C_003Eo__36._003C_003Ep__3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(bool), typeof(SimpleClient<T>)));
        //    }
        //    Func<CallSite, object, bool> target = _003C_003Eo__36._003C_003Ep__3.Target;
        //    CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__36._003C_003Ep__3;
        //    if (_003C_003Eo__36._003C_003Ep__2 == null)
        //    {
        //        _003C_003Eo__36._003C_003Ep__2 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.GreaterThan, typeof(SimpleClient<T>), new CSharpArgumentInfo[2]
        //        {
        //            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
        //            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
        //        }));
        //    }
        //    Func<CallSite, object, int, object> target2 = _003C_003Eo__36._003C_003Ep__2.Target;
        //    CallSite<Func<CallSite, object, int, object>> _003C_003Ep__2 = _003C_003Eo__36._003C_003Ep__2;
        //    if (_003C_003Eo__36._003C_003Ep__1 == null)
        //    {
        //        _003C_003Eo__36._003C_003Ep__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ExecuteCommand", null, typeof(SimpleClient<T>), new CSharpArgumentInfo[1]
        //        {
        //            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
        //        }));
        //    }
        //    Func<CallSite, object, object> target3 = _003C_003Eo__36._003C_003Ep__1.Target;
        //    CallSite<Func<CallSite, object, object>> _003C_003Ep__3 = _003C_003Eo__36._003C_003Ep__1;
        //    if (_003C_003Eo__36._003C_003Ep__0 == null)
        //    {
        //        _003C_003Eo__36._003C_003Ep__0 = CallSite<Func<CallSite, IDeleteable<T>, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "In", null, typeof(SimpleClient<T>), new CSharpArgumentInfo[2]
        //        {
        //            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
        //            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
        //        }));
        //    }
        //    return target(_003C_003Ep__, target2(_003C_003Ep__2, target3(_003C_003Ep__3, _003C_003Eo__36._003C_003Ep__0.Target(_003C_003Eo__36._003C_003Ep__0, Context.Deleteable<T>(), id)), 0));
        //}

        //public bool DeleteByIds(dynamic[] ids)
        //{
        //    return Context.Deleteable<T>().In(ids).ExecuteCommand() > 0;
        //}
    }
}