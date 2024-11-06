using ContentControl实现一个简单的MVVM模式下的导航框架.Services;
using ContentControl实现一个简单的MVVM模式下的导航框架.ViewModels;
using ContentControl实现一个简单的MVVM模式下的导航框架.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace ContentControl实现一个简单的MVVM模式下的导航框架
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MainWindow>();
            services.AddTransient<GuideViewModel>();
            services.AddTransient<GuideView>();
            var serviceProvider = services.BuildServiceProvider();
            var navigationService = serviceProvider.GetService<INavigationService>() as NavigationService;
            navigationService.Register<MainWindowViewModel, MainWindow>();
            navigationService.Register<GuideViewModel, GuideView>();

            // 创建主窗口并设置其DataContext
            var mainWindow = new MainWindow
            {
                DataContext = serviceProvider.GetService<MainWindowViewModel>()
            };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}