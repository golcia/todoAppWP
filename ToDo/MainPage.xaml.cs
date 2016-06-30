using System;
using ToDo.Entity;
using ToDo.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ToDo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage() {
            this.InitializeComponent();
            DataContext = MyViewModel.I();
            getViewModel().loadLocalSettings();
            NetworkProvider provider = new NetworkProvider();
            if (getViewModel().AllTask != true) {
                provider.getOwnerTasks(getViewModel());
            }
        }

    private MyViewModel getViewModel() {
            return DataContext as MyViewModel;
        }

        private async void Owner_Task_Click(object sender, RoutedEventArgs e) {
            NetworkProvider provider = new NetworkProvider();
            provider.getOwnerTasks(getViewModel());
            this.Frame.Navigate(typeof(MainPage));

        }
        private async void All_Task_Click(object sender, RoutedEventArgs e) {
            getViewModel().AllTask = true;
            NetworkProvider provider = new NetworkProvider();
            provider.getTasks(getViewModel());
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Add_Click(object sender, RoutedEventArgs e) {   
            this.Frame.Navigate(typeof(AddPage));
        }
        
        private void Logout_Click(object sender, RoutedEventArgs e) {
            getViewModel().removeLocalSettings();
            DataContext = null;
            this.Frame.Navigate(typeof(LoginPage));
        }
        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ListBox1.SelectedItem == null) {
                return;
            } else {
               getViewModel().CurrentObject = (Task)ListBox1.SelectedItem;
                Frame.Navigate(typeof(DetailsPage));
            }
        }        
    }
}
