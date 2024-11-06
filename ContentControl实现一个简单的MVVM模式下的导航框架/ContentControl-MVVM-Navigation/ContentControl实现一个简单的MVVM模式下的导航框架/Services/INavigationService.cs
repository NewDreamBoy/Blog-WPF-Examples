namespace ContentControl实现一个简单的MVVM模式下的导航框架.Services
{
    public interface INavigationService
    {
        /// <summary>
        /// 导航到某个ViewModel对应的View页面 并进行Content绑定
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        void NavigateTo<TViewModel>() where TViewModel : class;
    }
}