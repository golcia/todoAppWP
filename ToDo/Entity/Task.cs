using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.ViewModels;

namespace ToDo.Entity
{
    class Task
    {
        public string id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public string ownerId { get; set; }
        public string createdAt { get; set; }

        public Task ( string title, string value, string id)
        {
            this.title = title;
            this.value = value;
            this.ownerId = MyViewModel.I().OwnerId;
            if (id == "") this.id = "0";
            else this.id = id;
            this.createdAt = DateTime.Now.ToString();
        }

        public string SerializeToDoTask()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
