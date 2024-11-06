using ContentControl实现一个简单的MVVM模式下的导航框架.Core;
using ContentControl实现一个简单的MVVM模式下的导航框架.Services;
using System.Windows.Input;

namespace ContentControl实现一个简单的MVVM模式下的导航框架.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly INavigationService _navigationService;
        public ICommand NavigateToGuideCommand { get; }

        public MainWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToGuideCommand = new RelayCommand(NavigateToGuide);
        }

        public void NavigateToGuide()
        {
            //跳转到GuideViewModel对应的View页面
            _navigationService.NavigateTo<GuideViewModel>();
        }
    }
}