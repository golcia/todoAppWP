using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ToDo.Entity;
using ToDo.ViewModels;

namespace ToDo
{
    class NetworkProvider
    {

        //CONST REST
        private const string REST_BASE_URL = "http://windowsphoneuam.azurewebsites.net/";
        private const string REST_PATH = "api/todotasks/";
        private const string OWNER_SEARCH_PATH = "?OwnerId=";

        //GET
        public async void getTasks(MyViewModel DataContext) {
            using (HttpClient client = new HttpClient()) {
                var result = await client.GetAsync(REST_BASE_URL + "/" + REST_PATH);
                var items = await result.Content.ReadAsStringAsync();
                DataContext.ItemsCollection = JsonConvert.DeserializeObject<ObservableCollection<Entity.Task>>(items);
            }
        }
        //GET 
        public async void getOwnerTasks(MyViewModel DataContext){
            using (HttpClient client = new HttpClient()) {
                var result = await client.GetAsync(REST_BASE_URL + "/" + REST_PATH + OWNER_SEARCH_PATH + DataContext.OwnerId);
                var items = await result.Content.ReadAsStringAsync();
                DataContext.ItemsCollection = JsonConvert.DeserializeObject<ObservableCollection<Entity.Task>>(items);
                DataContext.AllTask = true;
            }
        }

        //POST
        public async void postTask(Entity.Task myTask) {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(REST_BASE_URL);
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, REST_PATH);
                request.Content = new StringContent(myTask.SerializeToDoTask(), Encoding.UTF8, "application/json");
                await client.SendAsync(request);
            }
        }


        //PUT
        public async void updateTask(Entity.Task myTask) {
            myTask.createdAt = DateTime.Now.ToString("dd'-'MM'-'yyyy HH:mm:ss");
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(REST_BASE_URL);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, REST_PATH + myTask.id);
                request.Content = new StringContent(myTask.SerializeToDoTask(), Encoding.UTF8, "application/json");
                await client.SendAsync(request);
            }
        }

        //DELETE
        public async void deleteTask(Entity.Task myTask) {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(REST_BASE_URL);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, REST_PATH + myTask.id);
                await client.SendAsync(request);

            }
        }
    }
}
