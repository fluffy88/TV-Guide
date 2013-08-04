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
using TV_Guide.Utils;

namespace TV_Guide
{
    public partial class MoviesPage : PhoneApplicationPage
    {
        private MoviesViewModel _viewModel;

        public MoviesPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _viewModel = new MoviesViewModel();
            MovieList.DataContext = _viewModel;

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingUtil.SetupLoader(this, _viewModel, "Loading movie data...");
        }
    }
}