using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;

using Autofac;
using Autofac.Integration.WebApi;

namespace Auth.Infrastructure.Ioc
{
    public class AutoFacApiConfig
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// 获取实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    RegisterContainer();
                }
                return container.Resolve<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"IOC实例化类型{typeof(T).GetType().FullName}出错!" + ex.Message);
            }
        }

        /// <summary>
        /// 注册到容器中
        /// </summary>
        public static void RegisterContainer()
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();

            var baseType = typeof(IDependency);

            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>();//获取所有的程序集

            builder.RegisterAssemblyTypes(assemblys.ToArray())
            .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract)//注册所有实现IDependency接口的类
            .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterWebApiFilterProvider(config);//注册到筛选器
            builder.RegisterApiControllers(Assembly.GetCallingAssembly());//注册api控制器的实现

            container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}