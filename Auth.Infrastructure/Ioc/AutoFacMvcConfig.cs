using System;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;

namespace Auth.Infrastructure.Ioc
{
    public class AutoFacMvcConfig
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
            var builder = new ContainerBuilder();

            var baseType = typeof(IDependency);

            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>();//获取所有的程序集

            builder.RegisterAssemblyTypes(assemblys.ToArray())
            .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract)//注册所有实现IDependency接口的类
            .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterFilterProvider();//注册到筛选器
            builder.RegisterControllers(Assembly.GetCallingAssembly());//注册mvc容器的实现

            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}