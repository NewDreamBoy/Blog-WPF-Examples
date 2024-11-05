using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Windows;

namespace 实现View和ViewModel自动绑定
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider AppServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAutoVmBinding(Assembly.GetExecutingAssembly());
            AppServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}