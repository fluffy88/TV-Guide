using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TV_Guide.ViewModels;
using System.Windows.Data;
using TV_Guide.Utils;

namespace TV_Guide
{
    public partial class ChannelPage : PhoneApplicationPage
    {
        TVListingViewModel _viewModel;

        public ChannelPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            String page = Uri.UnescapeDataString(NavigationContext.QueryString["page"]);
            String channel = Uri.UnescapeDataString(NavigationContext.QueryString["channel"]);
            ChannelName.Text = channel;

            _viewModel = new TVListingViewModel();
            ListingList.DataContext = _viewModel;
            _viewModel.LoadPage(page);

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingUtil.SetupLoader(this, _viewModel, "Loading program data...");
        }
    }
}