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
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
            DataContext = MyViewModel.I();
        }
        private MyViewModel getViewModel()
        {
            return DataContext as MyViewModel;
        }

        private async void onClickLoginButton(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text != "")
            {
                getViewModel().saveLocalSettings(usernameTextBox.Text);
                this.Frame.Navigate(typeof(MainPage));
                
             
            }
            else
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                var nullUserDialog = loader.GetString("nullUserDialog");
                MessageDialog error = new MessageDialog(nullUserDialog);
                await error.ShowAsync();
            }
           
        }
        private async void onClickAboutButton(object sender, RoutedEventArgs e)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            var aboutMeDialogAuthor = loader.GetString("aboutMeDialogAuthor");
            var aboutMeDialogEmail = loader.GetString("aboutMeDialogEmail");
            MessageDialog aboutDialog = new MessageDialog(aboutMeDialogAuthor + "\n" + aboutMeDialogEmail);
            await aboutDialog.ShowAsync();

        }
    }
}
