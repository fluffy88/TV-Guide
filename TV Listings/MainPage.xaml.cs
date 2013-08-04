using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TV_Guide.Resources;
using System.IO;
using TV_Guide.ViewModels;
using System.Windows.Data;
using TV_Guide.JSONModels;
using TV_Guide.Utils;

namespace TV_Guide
{
    public partial class MainPage : PhoneApplicationPage
    {
        ChannelViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();

            _viewModel = new ChannelViewModel();
            ChannelList.DataContext = _viewModel;
            _viewModel.LoadPage();

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingUtil.SetupLoader(this, _viewModel, "Loading channels...");
        }

        private void ChannelList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var listBox = (LongListSelector)sender;
            var selectedChannel = (Channel)listBox.SelectedItem;

            if (selectedChannel != null)
            {
                String pageUrl = String.Format("/ChannelPage.xaml?page={0}&channel={1}", selectedChannel.url, Uri.EscapeDataString(selectedChannel.channel));
                NavigationService.Navigate(new Uri(pageUrl, UriKind.Relative));
            }
        }
    }
}