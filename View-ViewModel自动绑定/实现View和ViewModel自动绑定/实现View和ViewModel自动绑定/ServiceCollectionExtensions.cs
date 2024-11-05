using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace 实现View和ViewModel自动绑定
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 拓展方法，自动注册所有实现了ViewModelBase的类
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="assembly">程序集</param>
        /// <returns></returns>
        public static IServiceCollection AddAutoVmBinding(this IServiceCollection services, Assembly assembly)
        {
            //获取ViewModelBase的类型
            var viewModelTypes = typeof(ViewModelBase);
            //获取程序集中符合条件的类
            var enumerable = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && viewModelTypes.IsAssignableFrom(t));
            foreach (var viewModelType in enumerable)
            {
                //注册到依赖注入容器中
                services.AddTransient(viewModelType);
            }
            return services;
        }
    }
}