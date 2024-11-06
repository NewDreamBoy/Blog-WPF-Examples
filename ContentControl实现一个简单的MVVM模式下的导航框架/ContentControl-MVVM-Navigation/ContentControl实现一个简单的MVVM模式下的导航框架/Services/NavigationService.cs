using System.Windows;

namespace ContentControl实现一个简单的MVVM模式下的导航框架.Services
{
    internal class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<Type, Type> _viewModelToViewMap;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _viewModelToViewMap = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// 注册ViewModel和View的映射关系
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TView"></typeparam>
        public void Register<TViewModel, TView>() where TViewModel : class where TView : FrameworkElement
        {
            _viewModelToViewMap[typeof(TViewModel)] = typeof(TView);
        }

        /// <summary>
        /// 导航到指定ViewModel对应的View
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        public void NavigateTo<TViewModel>() where TViewModel : class
        {
            //获得ViewModel对应的View
            var viewType = _viewModelToViewMap[typeof(TViewModel)];
            //获得View实例
            var view = (FrameworkElement)_serviceProvider.GetService(viewType);
            //获得ViewModel实例
            var viewModel = _serviceProvider.GetService(typeof(TViewModel));
            view.DataContext = viewModel;
            //将View设置为MainWindow的Content
            (Application.Current.MainWindow as MainWindow).MainContent.Content = view;
        }
    }
}