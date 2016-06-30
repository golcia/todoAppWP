using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ToDo.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            this.InitializeComponent();
            DataContext = MyViewModel.I();
        }
        private MyViewModel getViewModel()
        {
            return DataContext as MyViewModel;
        }

        private  void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
        private async void Edit_Click(object sender, RoutedEventArgs e)
        {

            if (getViewModel().CurrentObject.ownerId.Equals(getViewModel().OwnerId))
            {
                Frame.Navigate(typeof(EditPage));
            }
            else
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                var warnDialog = loader.GetString("warnDialog");
                var dialog = new MessageDialog(warnDialog);
                await dialog.ShowAsync();
            }
        }
    }
}
