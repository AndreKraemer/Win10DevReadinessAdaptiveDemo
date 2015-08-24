using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AdaptiveDemo.Data;
using System.ComponentModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AdaptiveDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {

        private Session _currentSession = SessionData.GetById(1);
        public Session CurrentSession
        {
            get
            {
                return _currentSession;
            }
            set
            {
                if (value != _currentSession)
                {
                    _currentSession = value;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CurrentSession")); 
                }
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.NavigationListView.ItemsSource = SessionData.GetAll();
        }
        private void SplitViewButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void NavigationListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentSession = e.ClickedItem as Session;
            if(MySplitView.DisplayMode == SplitViewDisplayMode.Overlay)
            {
                MySplitView.IsPaneOpen = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Adaptive Code
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Vibrate(0);
        }



        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Vibrate(1);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Vibrate(2);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Vibrate(3);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Vibrate(4);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            Vibrate(5);
        }

        private static void Vibrate(int seconds)
        {
            var api = "Windows.Phone.Devices.Notification.VibrationDevice";
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent(api))
            {

                var dev = Windows.Phone.Devices.Notification.VibrationDevice.GetDefault();
                dev.Vibrate(TimeSpan.FromSeconds(seconds));
            }
        }

        #endregion
    }
}
