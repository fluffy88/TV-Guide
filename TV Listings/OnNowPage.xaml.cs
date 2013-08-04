using Microsoft.Phone.Controls;
using System;
using System.Windows;
using TV_Guide.Utils;
using TV_Guide.ViewModels;

namespace TV_Guide
{
    public partial class OnNowPage : PhoneApplicationPage
    {
        private OnNowViewModel _viewModel;

        public OnNowPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _viewModel = new OnNowViewModel();
            ProgramList.DataContext = _viewModel;

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingUtil.SetupLoader(this, _viewModel, "Loading program data...");
        }
    }
}