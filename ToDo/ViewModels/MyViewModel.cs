using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using ToDo.Entity;
using Windows.Storage;

namespace ToDo.ViewModels
{
    class MyViewModel : ViewModel {
    
        //CONST LOCAL SETTINGS
        private const string LOCAL_SETTINGS_TAG = "Owner";

        private string ownerId { get; set; }
        public string OwnerId {
            get { return ownerId; }
            set { ownerId = value; }
        }

        private bool allTask { get; set; } = false;
        public bool AllTask {
            get { return allTask; }
            set { allTask = value; }
        }

        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private static MyViewModel instance { get; set; }

        private Task currentObject { get; set; }
        public Task CurrentObject {
            get { return currentObject; }
            set { currentObject = value; OnPropertyChanged("CurrentObject"); }
        }

        private ObservableCollection<Task> itemsCollection;
        public ObservableCollection<Task> ItemsCollection {
            get { return itemsCollection;}
            set { itemsCollection = value;
                OnPropertyChanged("ItemsCollection");
            }
        }

        public static MyViewModel I() {
            if (instance == null) {
                instance = new MyViewModel();
            }
            return instance;
        }

        public MyViewModel(){}

        public void saveLocalSettings(String username) {
            localSettings.Values[LOCAL_SETTINGS_TAG] = username;
        }

        public void loadLocalSettings() {
            Object value = localSettings.Values[LOCAL_SETTINGS_TAG];
            if (value == null) {
                ownerId = ""; 
            } else {
                ownerId = value.ToString();
            }
        }
        public void removeLocalSettings() {
            localSettings.Values.Remove(LOCAL_SETTINGS_TAG);
            ownerId = "";
        }
    }
}
